using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace services
{
   public class EmailService
    {
        private MailMessage em;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            //server.Credentials= new NetworkCredential("sendertoreset@gmail.com", "!qwe123rty");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.office365.com";
        }

        public void armarCorreo(string emailDestino, string asunto)
        {
            em = new MailMessage();
            em.From = new MailAddress("reseter@gmail.com");
            em.To.Add(emailDestino);
            em.Subject = asunto;
            em.IsBodyHtml = true;
            em.Body = "<h1>Reporte de materias a las que se ha inscripto</h1> <br>Hola, te inscribiste.... bla bla";

        }


        public bool enviarEmail()
        {
            try
            {
                server.Send(em);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
