using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solid.Services.SingleResponsabilityPrinciple
{
    public class PasswordEncrypter
    {
        private string _userPassword;
        public PasswordEncrypter(string password)
        {
            _userPassword = password;
        }

        public string Encrypt(string userPass)
        {
            var userPassBytes = System.Text.Encoding.UTF8.GetBytes(userPass);
            return Convert.ToBase64String(userPassBytes);
        }
    }
}
