using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
namespace SFHSTrackAndField
{
    public class Helper
    {
        public static bool loggedIn = false;
        private static Random random = new Random();

        public static string Encrypt(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                return Convert.ToBase64String(hash);
            }
        }
        public static void changeLoggedInStatus()
        {
            loggedIn = !loggedIn;
        }
        public static void SendMail(string Subject, string Body, string To)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("bsmith234432@gmail.com");
                mail.To.Add(To);
                mail.Body = Body;
                mail.Subject = Subject;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("bsmith234432@gmail.com", "thejumpynoob678");
                client.Send(mail);
                mail = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string GetCode(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
        public static bool VerifyCode(string code, string input)
        {
            return code == input;
        }
    }
}