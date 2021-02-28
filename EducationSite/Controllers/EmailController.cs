using System;
using System.Collections;
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

        public ActionResult Index()

        {
          
            return View();
        }
        // GET: Email
        public ActionResult IndexTest()

        {
            var teacher = db.Teachers.Where(t => t.Employee == false && t.Available == true);
            ArrayList recipient = new ArrayList();

            foreach (Teacher t_ in teacher)
            {
                recipient.Add(t_.Email);
            }

            return View(teacher);
   
        }

        [HttpPost]
        public ActionResult Index(EducationSite.Models.Email model)
        {

            const string from_ = "dennyamiruddin41@gmail.com";
            const string pass_ = "utpocvlfbcqwucds";
            const string host_ = "smtp.gmail.com";
            const int port_ = 587;



            var teacher = db.Teachers.Where(t => t.Employee == false);
            ArrayList recipient = new ArrayList();

            foreach (Teacher t_ in teacher)
            {
                recipient.Add(t_.Email);
            }



            //MailMessage mm = new MailMessage(from_, model.to);

            MailMessage mm = new MailMessage();

            mm.From = new MailAddress(from_);

            foreach (String list in recipient)
            {
                mm.To.Add(list);
            }

            mm.Subject = model.subject;

            mm.Body = model.message;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = host_;
            smtp.Port = port_;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(from_, pass_);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Mail has been sent successfully!";
            return View();
        }


    }
}