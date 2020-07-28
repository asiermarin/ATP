using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public UserViewModel(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
