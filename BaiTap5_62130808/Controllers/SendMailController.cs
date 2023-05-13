using BaiTap5_62130808.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap5_62130808.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(MailInfo model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Confirm");
            /*return RedirectToAction("Index", "Mail");*/
        }
        public ActionResult Confirm(MailInfo model)
        {
            return View();
        }
        /*public ActionResult Default()
        {
            return RedirectToAction("Default", "Home");
        }
        public ActionResult RegisterEmp()
        {
            return RedirectToAction("RegisterEmp", "RegisterEmp");
        }
        public ActionResult ChangeBanner()
        {
            return RedirectToAction("ChangeBanner", "ChangeBanner");
        }*/
        
    }
}