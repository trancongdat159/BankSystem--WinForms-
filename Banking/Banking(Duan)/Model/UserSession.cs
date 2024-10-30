using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    internal class UserSession
    {
        public static string Id { get; set; }
        public static string Password { get; set; }
        public static string Role { get; set; }

        public UserSession(string id, string password, string role)
        {
            Id = id;
            Password = password;
            Role = role;
        }

        public UserSession() { }
        public void Clear()
        {
            Id = null;
            Password = null;
            Role = null;
        }
    }
}
