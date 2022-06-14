using MantisTester.Models;
using OpaqueMail;

namespace MantisTester.Controllers
{
    public class EmailController : BaseController
    {
        public EmailController(ControllersManager manager) : base(manager) { }

        public string GetLastMail(AuthModel account)
        {
            for (int i = 0; i < 20; i++)
            {
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.UserName, account.Password, false);
                pop3.Connect();
                pop3.Authenticate();
                if (pop3.GetMessageCount() > 0)
                {
                    MailMessage message = pop3.GetMessage(1);
                    string body = message.Body;
                    pop3.DeleteMessage(1);
                    return body;
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }
            return null;
        }
    }
}