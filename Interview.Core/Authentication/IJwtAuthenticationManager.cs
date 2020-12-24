using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
