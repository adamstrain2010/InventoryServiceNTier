using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.Data.Entities;

namespace InventoryServiceNTier.Data.Interfaces
{
    public interface IUserInfoManagerRepository
    {
        public UserInfo CreateUserInfo(UserInfo userInfo);
    }
}
