using MantisTester.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTester.Tests
{
    public class WithAuth : BaseTest
    {
        [SetUp]
        public void Login()
        {
            Manager.AuthController.Login(AuthModel.GetAdmin());
        }

        [TearDown]
        public void Logout()
        {
            Manager.AuthController.Logout();
        }
    }
}
