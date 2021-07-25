using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApplication.UI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            return View(cm.GetList().Where(x=> x.ContactStatus==false).ToList());
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            var contactList = cm.GetList();
            int contactCount = contactList.Where(x=> x.ContactStatus==false).ToList().Count();
            int messageList = mm.GetListInbox().Where(x=> x.MessageStatus==false).ToList().Count();
            int messageListSendBox = mm.GetListSendbox().Where(x=> x.MessageStatus==false).ToList().Count();
            int getTrashContactCount = contactList.Where(x => x.ContactStatus == true).ToList().Count();
            int getTrashMessageListCount = mm.GetList().Where(x => x.MessageStatus == true).ToList().Count();
            int getInboxMessage = mm.GetListInbox().Where(x => x.ReadStatus == false && x.MessageStatus==false).ToList().Count();
            
            ViewBag.inboxCount = messageList.ToString();
            ViewBag.sendboxCount = messageListSendBox.ToString();
            ViewBag.contactCount = contactCount.ToString();
            ViewBag.trashCount = (getTrashMessageListCount + getTrashContactCount).ToString();
            ViewBag.draftCount = mm.GetList().Where(x => x.MessageDraftStatus == true).ToList().Count().ToString();
            ViewBag.inboxReadCount = getInboxMessage.ToString();
            return PartialView();
        }
        public ActionResult UpdateContact(int id)
        {
            var getContact = cm.GetById(id);
            getContact.ContactStatus = true;
            cm.UpdateContact(getContact);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id)
        {
            var getContact = cm.GetById(id);
            cm.DeleteContact(getContact);
            return RedirectToAction("TrashMessage", "Message");
        }
    }
}