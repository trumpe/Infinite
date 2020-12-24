using AutoMapper;
using Interview.Core.Dtos;
using Interview.Core.Entities;
using Interview.Core.Intefaces;
using Interview.Core.Intefaces.AutoMaper_interface;
using Interview.Core.Intefaces.Repo_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _autoMapper;

    
        public UserService(IAutoMapper autoMapper, IUserRepo userRepo)
        {
            _autoMapper = autoMapper.Get();
            _userRepo = userRepo;
        }
        public bool LogIn(string username,string password)
        {
           return _userRepo.Login(username,password);
        }
        public UserDto Create(UserDto userDto)
        {
            try
            {
                var result = _userRepo.CheckExistingUserByUsername(userDto.Username);
                if (result)
                {
                    return null;
                }
                var user = new User()
                {
                    Password = userDto.Password,
                    Username = userDto.Username
                };
                user = _userRepo.Create(user);

                userDto.Username = user.Username;
                userDto.Password = user.Password;
                userDto.ID = user.ID;

                return userDto;
            }
            catch (Exception)
            {

                throw;
            }          

        }
        public UserDto GetUserByName(string name)
        {
           var user =  _userRepo.GetUserByName(name);
           return _autoMapper.Map<User, UserDto>(user);

        }
        ~UserService()
        {           
        }
    }
}
