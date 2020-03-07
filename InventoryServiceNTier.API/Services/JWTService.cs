using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using InventoryServiceNTier.API.Models;
using InventoryServiceNTier.Data.Entities;

using Microsoft.AspNetCore.Mvc;

namespace InventoryServiceNTier.API.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        private readonly InventoryContext _context;
        public JWTService(IConfiguration configuration, InventoryContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<object> ConstructToken(UserInfoDTO _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return new { data = new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token)) };

                }
                else
                {
                    return new { data = new UnauthorizedObjectResult("Invalid Credentials") };
                }
            }
            else
            {
                return new { data = new BadRequestObjectResult("Required Parameters Not Received") };
            }
        }

        public async Task<UserInfo> GetUser(string email, string password)
        {
            return await _context.UserInfo.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
