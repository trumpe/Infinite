using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Dtos
{
    public class UserDto
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
