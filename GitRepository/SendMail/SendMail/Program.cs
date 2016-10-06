using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Mail maildoc = new Mail();
            maildoc.SendMail();

            if (!EventLog.SourceExists("MySource"))
            {
                // An event log source should not be created and immediately used. 
                // There is a latency time to enable the source, it should be created 
                // prior to executing the application that uses the source. 
                // Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatingEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered. 
                return;
            }

        }
    }
    public class Mail
    {
        public void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("");

                mail.From = new MailAddress("mp700@wp.pl");
                mail.To.Add("michael.patora@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Host = "smtp.wp.pl";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mp700", "mp");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("mail Send");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
