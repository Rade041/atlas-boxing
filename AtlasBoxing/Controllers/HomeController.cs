using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AtlasBoxing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Meet the Founders";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find us at";

            return View();
        }

        public ActionResult Classes()
        {
            ViewBag.Message = "Timetables";


            return View();
        }
        public ActionResult YouthCommunityHub()
        {
            ViewBag.Message = "Youth Community Hub";

            return View();
        }
        public ActionResult Pricing()
        {
            ViewBag.Message = "Pricing";

            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string Name, string Email, string Message)
        {
            try
            {
                var fromAddress = new MailAddress(Email, Name);
                var toAddress = new MailAddress("atlasboxing@yahoo.com");
                const string fromPassword = "your-email-password"; // Replace with your email account's password
                const string subject = "New Contact Form Submission";
                string body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.your-email-provider.com", // Replace with your SMTP server address
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                ViewBag.Message = "Your message has been sent successfully!";
            }
            catch
            {
                ViewBag.Message = "There was an error sending your message. Please try again later.";
            }

            return View("Contact");
        }
    }
}       