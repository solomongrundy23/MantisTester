using MantisTester.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTester.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(ControllersManager manager) : base(manager)
        {
        }

        public ControllersManager Login(AuthModel authModel)
        {
            FillTextBox(By.Id("username"), authModel.UserName);
            FillTextBox(By.Id("password"), authModel.Password);
            Driver.FindElement(By.CssSelector("#login-form > fieldset > span > input")).Click();
            return Manager;
        }

        public ControllersManager Logout()
        {
            Driver.FindElement(By.Id("logout-link")).Click();
            return Manager;
        }
    }
}
