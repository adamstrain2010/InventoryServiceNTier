using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.Data.Entities;
using InventoryServiceNTier.API.Models;

namespace InventoryServiceNTier.API.Services
{
    public interface IJWTService
    {
        public Task<object> ConstructToken(UserInfoDTO _userData);
    }
}
