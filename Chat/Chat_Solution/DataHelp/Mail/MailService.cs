using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataHelp.Mail
{
	public static class MailService
	{
		public static bool SendMailRegisterSuccess(string email, string username)
		{
            if (!IsValidEmail(email)) { return false; }

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("trianglesoftmusala@gmail.com");
            mail.To.Add(email);
            mail.Subject = $"TriangleSoft congratulates you!";
            mail.Body = $"You Successfuly registered in TriangleSoft, {username}!";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("trianglesoftmusala", "triangle654");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return true;
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
