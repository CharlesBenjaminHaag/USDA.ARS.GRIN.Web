using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;
using System.Collections.ObjectModel;
using USDA.ARS.GRIN.Web.DataLayer;
using USDA.ARS.GRIN.Common.Library.Email;

namespace USDA.ARS.GRIN.Web.ViewModelLayer
{
    public class ContactViewModel
    {
        private string _ContactType = String.Empty;
        private bool _CopySenderOption = false;
        private SMTPMailMessage _MailMessage = new SMTPMailMessage();

        public void SendMessage()
        {
            SMTPManager sMTPManager = new SMTPManager();
            SMTPMailMessage sMTPMailMessage = new SMTPMailMessage();
            sMTPMailMessage.To = ConfigurationManager.AppSettings["EmailContactTo"];
            sMTPMailMessage.From = MailMessage.From;
                      
            if (CopySenderOption == true)
            {
                sMTPMailMessage.CC = sMTPMailMessage.From;
            }

            switch (ContactType)
            {
                case "GEN":
                    sMTPMailMessage.Subject = "ARS-GRIN Site Contact: General Inquiry";
                    break;
                case "ERR":
                    sMTPMailMessage.Subject = "ARS-GRIN Site Contact: Site Error";
                    break;
                case "OTH":
                    sMTPMailMessage.Subject = "ARS-GRIN Site Contact: Other";
                    break;
            }
            sMTPMailMessage.Body = "<strong>Sender:</strong> " + sMTPMailMessage.From + "<br><br><strong>Message:</strong><br>" + MailMessage.Body;
            sMTPMailMessage.IsHtml = true;
            sMTPManager.SendMessage(sMTPMailMessage);
        }

        public string ContactType
        {
            get { return _ContactType; }
            set { _ContactType = value; }
        }
        public bool CopySenderOption
        {
            get { return _CopySenderOption; }
            set { _CopySenderOption = value; }
        }
        public SMTPMailMessage MailMessage
        {
            get { return _MailMessage; }
            set { _MailMessage = value; }
        }
    }
}
