using solid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services.SingleResponsabilityPrinciple
{
    public class UserRegistry
    {
        public UserRegistry()
        {

        }
        public User CreateUser(User newUser)
        {
            var passEncrypt = new PasswordEncrypter(newUser.Password);
            return new User(newUser.Name, passEncrypt.Encrypt(newUser.Password));
        }
    }
}
