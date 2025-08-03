using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // Gelen kutusu (Inbox)
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p)
                .Where(x => !x.IsTrash && !x.IsDraft && !x.IsSpam)
                .ToList();
            return View(messagelist);
        }

        // Gönderilenler (Sendbox)
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(p)
                .Where(x => !x.IsTrash && !x.IsDraft)
                .ToList();
            return View(messagelist);
        }

        // Taslaklar
        public ActionResult Draft()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(p)
                .Where(x => x.IsDraft && !x.IsTrash)
                .ToList();
            return View(messagelist);
        }

        // Çöp kutusu
        public ActionResult Trash()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p)
                .Where(x => x.IsTrash)
                .ToList();
            return View(messagelist);
        }

        // Spam kutusu
        public ActionResult Spam()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p)
                .Where(x => x.IsSpam && !x.IsTrash)
                .ToList();
            return View(messagelist);
        }

        // Mesajı çöp kutusuna taşı
        public ActionResult MoveToTrash(int id)
        {
            var message = messageManager.GetById(id);
            message.IsTrash = true;
            messageManager.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }

        // Mesajı spam'e taşı
        public ActionResult MoveToSpam(int id)
        {
            var message = messageManager.GetById(id);
            message.IsSpam = true;
            messageManager.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }

        // Sidebar menü
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        // Gelen mesaj detayı
        public ActionResult GetInboxMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }

        // Gönderilen mesaj detayı
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }

        // Yeni mesaj formu (GET)
        [HttpGet]
        public ActionResult NewMessage()
        {
            WriterManager writerManager = new WriterManager(new EfWriterDal());
            string currentWriterMail = (string)Session["WriterMail"];

            var writerList = writerManager.GetList()
                .Where(x => x.WriterMail != currentWriterMail)
                .Select(x => new SelectListItem
                {
                    Text = x.WriterName,
                    Value = x.WriterMail
                }).ToList();

            ViewBag.WriterList = writerList;

            return View();
        }



        // Yeni mesaj oluşturma (POST)
        [HttpPost]
        public ActionResult NewMessage(Message p, string draft = null)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(p);

            if (result.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Now;
                p.IsDraft = !string.IsNullOrEmpty(draft);
                p.IsTrash = false;
                p.IsSpam = false;

                messageManager.MessageAdd(p);

                if (p.IsDraft)
                    return RedirectToAction("Draft");
                else
                    return RedirectToAction("Sendbox");
            }
            else
            {
                // ViewBag.WriterList yeniden set edilmeli, yoksa view hata verir!
                WriterManager writerManager = new WriterManager(new EfWriterDal());
                var writerValues = writerManager.GetList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.WriterName,
                        Value = x.WriterMail
                    })
                    .ToList();

                ViewBag.WriterList = writerValues;

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
        }

    }
}
