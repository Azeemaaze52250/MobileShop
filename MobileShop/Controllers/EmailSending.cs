using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MobileShop.Controllers
{
    public class EmailSending
    {
        public string ManagerEmail = "aaze52250@gmail.com"; 
        public void SendEmail(string Subject,string msgBody,string To)
        {
            try
            {
                MailMessage oEmail = new MailMessage();
                oEmail.Subject = Subject;
                                    
                oEmail.Body = msgBody;
                oEmail.IsBodyHtml = true;

                oEmail.To.Add(new MailAddress(To));
                oEmail.CC.Add(new MailAddress(ManagerEmail));

               
                oEmail.From = new MailAddress("testemailazeem@gmail.com", "My Mobile Shop");
                


                SmtpClient oSMTP = new SmtpClient();
                oSMTP.Port = 587; //25, 465
                oSMTP.EnableSsl = true;
                oSMTP.Host = "smtp.gmail.com";

                oSMTP.Credentials = new System.Net.NetworkCredential("testemailazeem@gmail.com", "testemailazeem");

                oSMTP.Send(oEmail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
