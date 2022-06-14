using MantisTester.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTester.Tests
{
    public class BaseTest
    {
        public ControllersManager Manager
        {
            get
            {
                if (_controllersManager == null) throw new NullReferenceException("Manager is null");
                return _controllersManager;
            }
            private set { _controllersManager = value; }
        }
        private ControllersManager _controllersManager;

        [SetUp]
        public void InitManager()
        {
            Manager = ControllersManager.GetInstance();
        }

        [TearDown]
        public void CloseManager()
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }
    }
}
