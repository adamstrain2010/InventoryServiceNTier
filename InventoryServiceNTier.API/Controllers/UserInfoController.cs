using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using InventoryServiceNTier.API.Services;
using InventoryServiceNTier.API.Models;
using InventoryServiceNTier.Data.Entities;

using AutoMapper;

namespace InventoryServiceNTier.API.Controllers
{
    [ApiController]
    public class UserInfoController : Controller
    {

        private readonly IJWTService _JWTService;
        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public UserInfoController(IJWTService JWTService, IUserInfoService userInfoService, IMapper mapper)
        {
            _JWTService = JWTService;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/GetToken")]
        public async Task<object> GetToken(UserInfoDTO userData)
            {
            return await _JWTService.ConstructToken(userData);
        }

        [HttpPost]
        [Route("api/Register")]
        public object Register(UserInfoDTO userInfoDTO)
        {
            UserInfoDTO userInfoDTOOut = _userInfoService.RegisterUserInfo(userInfoDTO);
            return new OkObjectResult(userInfoDTOOut);

        }
    }
}