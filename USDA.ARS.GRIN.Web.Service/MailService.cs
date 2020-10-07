using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace USDA.ARS.GRIN.Web.Service
{
    public class MailService
    {
        public int SendMessage(string messageBody)
        {
            int retVal = 0;

            const string SMTP_PROXY = "mailproxy1.usda.gov";
            const string DEFAULT_SENDER = "id_action_request@ars-grin.gov";
            const string DEFAULT_RECIPIENT = "gary.kinard@usda.gov";
            const string DEFAULT_CC = "kurt.endress@usda.gov";
            
            MailAddress to = new MailAddress(DEFAULT_RECIPIENT);
            MailAddress from = new MailAddress(DEFAULT_SENDER);
            MailMessage message = new MailMessage(from, to);

            message.To.Add(DEFAULT_CC);

            // TEMP
            message.To.Add("benjamin.haag@usda.gov");

            message.Subject = "GRIN Account Request";
            message.Body = messageBody;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(SMTP_PROXY);

            try
            {
                client.Send(message);
                retVal = 1;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            return retVal;
        }
    }
}
