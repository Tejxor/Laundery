using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunderySystem.Models
{
    public class EmailSettingModel
    {
        public int id { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPServerEmailID { get; set; }
        public string SMTPDefaultSender { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPmailToCompany { get; set; }
        public string SMTPpassword { get; set; }

    }
}