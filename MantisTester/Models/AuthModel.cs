using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTester.Models
{
    public class AuthModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static AuthModel GetAdmin() => new AuthModel() { UserName = "administrator", Password = "root" };
    }
}
