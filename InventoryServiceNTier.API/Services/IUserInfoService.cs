using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.API.Models;

namespace InventoryServiceNTier.API.Services
{
    public interface IUserInfoService
    {
        public UserInfoDTO RegisterUserInfo(UserInfoDTO userInfoDTO);
    }
}
