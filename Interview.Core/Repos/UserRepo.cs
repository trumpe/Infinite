using Interview.Core.Context;
using Interview.Core.Dtos;
using Interview.Core.Entities;
using Interview.Core.Intefaces.Repo_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Core.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;

        public UserRepo(DatabaseContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            var created =  _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return created;
        }
        public bool CheckExistingUserByUsername(string username)
        {
            var result = _context.Users.Any(x => x.Username == username);          
            return result;
        }
        public bool Login(string username, string password)
        {
            return _context.Users.Any(x => x.Username == username && x.Password == password);

        }
        public User GetUserByName(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }
        ~UserRepo()
        {
            _context.Dispose();
        }

    }
}
