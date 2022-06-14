using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace MantisTester.Controllers
{
    public class ControllersManager
    {
        private readonly string portalUrl = "http://localhost/mantisbt";

        private static ThreadLocal<ControllersManager> _managers = new ThreadLocal<ControllersManager>();
        public static ControllersManager GetInstance()
        {
            if (!_managers.IsValueCreated)
            {
                _managers.Value = new ControllersManager();
            }
            return _managers.Value ?? throw new ArgumentNullException("Thread values == null");
        }

        private AuthController _authController;
        public AuthController AuthController
        {
            get
            {
                if (_authController == null) _authController = new AuthController(this);
                return _authController;
            }
        }

        private ManagmentController _managmentController;
        public ManagmentController ManagmentController
        {
            get
            {
                if (_managmentController == null) _managmentController = new ManagmentController(this);
                return _managmentController;
            }
        }


        public WebDriver Driver { get; private set; }

        private ControllersManager()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(portalUrl);
        }

        ~ControllersManager()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}