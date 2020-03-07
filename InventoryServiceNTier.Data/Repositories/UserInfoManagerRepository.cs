using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using InventoryServiceNTier.Data.Interfaces;
using InventoryServiceNTier.Data.Entities;

namespace InventoryServiceNTier.Data.Repositories
{
    public class UserInfoManagerRepository: IUserInfoManagerRepository
    {
        private readonly InventoryContext _context;

        public UserInfoManagerRepository(InventoryContext context)
        {
            _context = context;
        }

        public UserInfo CreateUserInfo(UserInfo userInfo)
        {
            _context.UserInfo.Add(userInfo);
            _context.SaveChanges();
            return userInfo;
        }
        
    }
}
