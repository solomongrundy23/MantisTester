using System;
using MantisTester.Models;
using MinimalisticTelnet;

namespace MantisTester.Controllers
{
    public class TelnetController : BaseController
    {
        public TelnetController(ControllersManager manager) : base(manager) { }

        public void Add(AuthModel account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.UserName + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public void Delete(AuthModel account)
        {
            if (!Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.UserName);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public bool Verify(AuthModel account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify " + account.UserName);
            string s = telnet.Read();
            System.Console.Out.WriteLine(s);
            return !s.Contains("does not exist");
        }

        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            return telnet;
        }

    }
}