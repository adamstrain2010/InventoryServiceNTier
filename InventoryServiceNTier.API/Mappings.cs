using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using InventoryServiceNTier.Data.Entities;
using InventoryServiceNTier.API.Models;


namespace InventoryServiceNTier.API
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<ProductDTO, Products>().ReverseMap();
            CreateMap<UserInfoDTO, UserInfo>().ReverseMap();
        }
    }
}
