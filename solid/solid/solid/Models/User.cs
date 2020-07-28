using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Models
{
    public class User
    {
        public User(string name, string pass)
        {
            Name = name;
            Password = pass;
        }

        public string Name { get; set; }
        
        public string Password { get; set; }
    }
}
