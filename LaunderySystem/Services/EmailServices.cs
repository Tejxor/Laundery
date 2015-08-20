using LaunderySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace LaunderySystem.Services
{
    public class EmailServices : BaseService
    {

        public EmailServices(LaunderyContext db)
        {
            this.db = db;
        }

        public EmailSettingModel GetEmailSettings(int? id)
        {
            try
            {
              
                return db.EmailSetting.AsNoTracking().First(c => c.id == id);
            }
            catch (Exception)
            {

                return null;
            }
            
        }



        /// <summary>
        ///     Send email to user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public void SendEmail(string toAddress, string subject, string message)
        {
            var emailSettings = GetEmailSettings(1);
            var smtp = SetUpSmtpClient(emailSettings);
            var mail = new MailMessage { From = new MailAddress(emailSettings.SMTPServerEmailID), Subject = subject, Body = message, IsBodyHtml = true };

            mail.To.Add(new MailAddress(toAddress));
            smtp.Send(mail);
        }

        private SmtpClient SetUpSmtpClient(EmailSettingModel emailSettings)
        {
           
            return new SmtpClient { Host = emailSettings.SMTPServer, Port = 587, UseDefaultCredentials = false, Credentials = new NetworkCredential(emailSettings.SMTPServerEmailID, emailSettings.SMTPpassword), EnableSsl = true };
        }

        public string ForgotPasswordContent(string newPassword)
        {
            return @"<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    
                                                                                                                                                                                                                                                                                                                                                                                                            
    <style type='text/css'>
        .ReadMsgBody {width: 100%; background-color: #ffffff;}
        .ExternalClass {width: 100%; background-color: #ffffff;}
        body     {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased;font-family: Arial, Helvetica, sans-serif}
        table {border-collapse: collapse;}
        
        @media only screen and (max-width: 640px)  {
                        body[yahoo] .deviceWidth {width:440px!important; padding:0;}    
                        body[yahoo] .center {text-align: center!important;}  
                }
                
        @media only screen and (max-width: 479px) {
                        body[yahoo] .deviceWidth {width:280px!important; padding:0;}    
                        body[yahoo] .center {text-align: center!important;}  
                }
    </style>
    </head>
    <body leftmargin='0' topmargin='0' marginwidth='0' marginheight='0' yahoo='fix' style='font-family: Arial, Helvetica, sans-serif'>

    <!-- Wrapper -->
    <table width='100%' border='0' cellpadding='0' cellspacing='0' align='center'>
        <tr>
            <td width='100%' valign='top' bgcolor='#ffffff' style='padding-top:20px'>
                
            <!--Start Header-->
            <table width='700' bgcolor='#fff' border='0' cellpadding='0' cellspacing='0' align='center' class='deviceWidth'>
                <tr>
                    <td style='padding: 6px 0px 0px'>
                        <table width='650' border='0' cellpadding='0' cellspacing='0' align='center' class='deviceWidth'>
                            <tr>
                                <td width='100%' >
                                    <!--Start logo-->
                                    <table  border='0' cellpadding='0' cellspacing='0' align='left' class='deviceWidth'>
                                        <tr>
                                            <td class='center' style='padding: 20px 0px 10px 0px'>
                                               logo
                                            </td>
                                        </tr>
                                    </table><!--End logo-->
                                    <!--Start nav-->
                                    
                                </td>
                            </tr>
                        </table>
                   </td>
                </tr>
            </table> 
            <!--End Header-->

                <!-- Start Headliner-->
                <table width='700' border='0' cellpadding='0' cellspacing='0' align='center' class='deviceWidth'>
                    <tr>
                        <td width='100%' valign='top' style='padding: 0px ' class='center'>
                            <a href='#'><img class='deviceWidth' width='700' hight='350' src='http://lorempixel.com/700/350/transport/'></a>
                        </td>
                    </tr>
                </table>
                <!-- End Headliner-->

                <!--Start Discount-->
                <table width='700' border='0' cellpadding='0' cellspacing='0' align='center' class='deviceWidth'>
                    <tr>
                        <td width='100%' style=' padding: 20px 0;' align='center' bgcolor='#f7f7f7'>
                            <!--Left Box-->
                            <table   border='0' cellpadding='0' cellspacing='0' align='center' class='deviceWidth'>
                                <tr>
                                    <td valign='top' class='left' style='font-size: 16px; color: #303030; font-weight: bold; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 25px; vertical-align: middle; padding: 0 20px 10px 20px;'>
                                         You have requested to reset your password.               
                                    </td>
                                </tr>
                            </table><!--End Left Box-->
                            <table>
                                <tr>
                                    <td  valign='top' style='padding: 7px 15px;  background-color: #27d7e7; ' class='center'>
                                        <h2>You new password is " + newPassword + @"</2>
                                    </td>                                   
                                 </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!--End Discount-->
 
                <div style='height:15px'>&nbsp;</div><!-- divider-->


            </td>
        </tr>
    </table> 
    <!-- End Wrapper -->
    </body>";
        }

    }
}