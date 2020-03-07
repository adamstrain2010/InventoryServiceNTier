using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.Data.Interfaces;
using InventoryServiceNTier.Data.Entities;
using InventoryServiceNTier.API.Models;

using AutoMapper;

namespace InventoryServiceNTier.API.Services
{
    public class UserInfoService: IUserInfoService
    {
        private readonly IUserInfoManagerRepository _userInfoManagerRepository;
        private readonly IMapper _mapper;
        public UserInfoService(IUserInfoManagerRepository userInfoManagerRepository, IMapper mapper) 
        {
            _userInfoManagerRepository = userInfoManagerRepository;
            _mapper = mapper;
        }

        public UserInfoDTO RegisterUserInfo(UserInfoDTO userInfoDTO)
        {
            UserInfo userInfo = _mapper.Map<UserInfo>(userInfoDTO);
            UserInfoDTO userInfoDTOOut =_mapper.Map<UserInfoDTO>(_userInfoManagerRepository.CreateUserInfo(userInfo));
            return userInfoDTO;
        }
    }
}
