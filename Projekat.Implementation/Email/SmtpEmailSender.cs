using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Projekat.Application.Email;

namespace Projekat.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(dto.SendTo);
            mail.From = new MailAddress("luka.vasic.bgd@gmail.com");
            mail.Subject = dto.Subject;

            mail.Body = dto.Content;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; 
            smtp.Credentials = new System.Net.NetworkCredential
                 ("luka.vasic.bgd@gmail.com", "visokaict"); 
            smtp.Port = 587;

            
            smtp.EnableSsl = true;
            smtp.Send(mail);
           
        }
    }
}
