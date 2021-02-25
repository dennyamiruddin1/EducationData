using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationSite.Models;
using System.Net;
using System.Net.Mail;


namespace EducationSite.Controllers
{
    public class EmailController : Controller
    {
        private EducationDataEntities db = new EducationDataEntities();
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectTeacher()
        {
            return View(db.Teachers.ToList());
        }

        [HttpPost]
        public ActionResult Index(EducationSite.Models.Email model)
        {
            MailMessage mm = new MailMessage("dennyamiruddin41@gmail.com", model.to);
            mm.Subject = model.subject;
            mm.Body = model.message;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("dennyamiruddin41@gmail.com", "utpocvlfbcqwucds");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Mail has been sent successfully!";
            return View();
        }
    }
}