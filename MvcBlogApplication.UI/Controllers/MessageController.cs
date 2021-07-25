using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApplication.UI.Controllers
{
    public class MessageController : Controller
    {
        // GET: Messsage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList.Where(x=> x.MessageStatus==false).ToList());
        }
        public ActionResult GetInboxDetails(int id)
        {
            var messageDetails = mm.GetById(id);
            messageDetails.ReadStatus = true;
            mm.MessageUpdate(messageDetails);
            return View(messageDetails);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var messageDetails = mm.GetById(id);
            return View(messageDetails);
        }
        public ActionResult Sendbox()
        {
            return View(mm.GetListSendbox().Where(x=> x.MessageStatus==false).ToList());
        }
        [HttpGet]
        public ActionResult NewMessage(int? id)
        {
            if (id == null)
            {
                return View();
            }
            return View(mm.GetById(id));
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, string draftStatus)
        {
            ValidationResult validationResult = mv.Validate(message);
            if (draftStatus == "1")
            {
                message.MessageDraftStatus = true;
                if (validationResult.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(message);
                    return RedirectToAction("Drafts");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            }

            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
        }
        public ActionResult Drafts()
        {
            return View(mm.GetList().Where(x => x.MessageDraftStatus == true).ToList());
        }
        public ActionResult GetDraftDetails(int id)
        {
            return View(mm.GetById(id));
        }
        public ActionResult TrashMessage()
        {
            var getTrashList = mm.GetList().Where(x => x.MessageStatus == true).ToList();
            var getContactTrashList = cm.GetList().Where(x => x.ContactStatus == true).ToList();
            ViewData["ContactList"] = getContactTrashList;
            return View(getTrashList);
        }
        
        public ActionResult DeleteMessage(int id)
        {
            var getMessage = mm.GetById(id);
            mm.MessageDelete(getMessage);            
            return RedirectToAction("TrashMessage");
        }
        
        public ActionResult DeleteInboxMessage(int id)
        {
            var getMessage = mm.GetById(id);
            getMessage.MessageStatus = true;
            mm.MessageUpdate(getMessage);
            return RedirectToAction("Inbox");
        }
        public ActionResult DeleteSendboxMessage(int id)
        {
            var getMessage = mm.GetById(id);
            getMessage.MessageStatus = true;
            mm.MessageUpdate(getMessage);
            return RedirectToAction("Sendbox");
        }
    }
}