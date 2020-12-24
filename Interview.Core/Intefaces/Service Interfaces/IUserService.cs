using Interview.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Intefaces
{
    public interface IUserService
    {
        public bool LogIn(string username,string password);

        public UserDto Create(UserDto userDto);
     
        public UserDto GetUserByName(string name);
       
    }
}
