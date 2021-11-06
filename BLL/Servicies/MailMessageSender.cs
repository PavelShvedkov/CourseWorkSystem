using System.Net;
using System.Net.Mail;
using BLL.Interface.Servicies;

namespace BLL.Servicies
{
    public class MailMessageSender: IMessageSender
    {
        public string EmailFrom { get; set; }
        
            public string EmailTo { get; set; }
        
            public string Subject { get; set; }
        
            public string Message { get; set; }

            public string Host { get; set; } = "smtp.gmail.com";
        
            public int Port { get; set; } = 587;
        
            public void Send()
            {
                using MailMessage mail = new MailMessage()
                {
                    //From = new MailAddress(From)
                    From = new MailAddress("anzhelika.kravchuk@gmail.com")
                };
                //mail.To.Add(To);
                mail.To.Add("anzhelika.kravchuk@gmail.com");
                mail.Subject = Subject;
                mail.Body = Message;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using SmtpClient smtp = new SmtpClient(Host, Port);
                smtp.Credentials = new NetworkCredential("anzhelika.kravchuk@gmail.com", "password here");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
    }
}