using Interview.Core.Dtos;
using Interview.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Intefaces.Repo_Interfaces
{
    public interface IUserRepo
    {
        public User Create(User user);
        public bool Login(string username, string password);
        public bool CheckExistingUserByUsername(string username);

        public User GetUserByName(string username);


    }
}
