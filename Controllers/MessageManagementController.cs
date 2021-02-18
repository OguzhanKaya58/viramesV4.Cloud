using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using viramesV4.Cloud.Helpers;
using viramesV4.Object.BusinessLogicLayer.System;
using viramesV4.Object.Factory;
using viramesV4.Object.HelperLayer;


namespace viramesV4.Cloud.Controllers
{
    [ViramesAuthorization]
    public class MessageManagementController : Controller
    {
        // GET: MessageManagement
        [HttpGet]
        public ActionResult InBoxMessage()
        {
            ViewBag.Isactive = 62;
            int user = Statics.GetUser().ID;
            List<Message> inBoxMsgList = virames<Message>.Initialize(new List<Message>())
                           .Where(x => x.ReceiverID == user && x.OwnerID == user && x.MessageLocationType == MessageLocationType.Received)
                           .GetList();
            return View(inBoxMsgList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            ViewBag.Isactive = 63;
            Message message = new Message();
            message.SenderID = Statics.GetUser().ID;
            ViewBag.Receiver = virames<User>.Initialize(new List<User>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            });
            return View(message);
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            if (Request.Form["summernote"] != null)
            {
                foreach (var item in Request.Form["summernote"])
                {
                    string i = item.ToString();
                }
            }
            if (ModelState.IsValid)
            {
                string[] users;
                string usersString = "";
                foreach (var item in Request.Form["users"])
                {
                    usersString += item.ToString();
                }
                users = usersString.Split(',');

                foreach (var item in users)
                {
                  
                }
                Message messagePost = new Message();
                messagePost.Sender = message.Sender;
                messagePost.Receiver = message.Receiver;
                messagePost.Subject = message.Subject;
                messagePost.MessageBody = message.MessageBody;
                message.Save();
               
            }
            return RedirectToAction("InBoxMessage");
        }
        [HttpGet]
        public ActionResult SendedMessage()
        {
            ViewBag.Isactive = 64;
            int user = Statics.GetUser().ID;
            List<Message> sendedMsgList = virames<Message>.Initialize(new List<Message>())
                           .Where(x => x.SenderID == user && x.OwnerID == user && x.MessageLocationType == MessageLocationType.Sended)
                           .GetList();
            return View(sendedMsgList);
        }
        [HttpGet]
        public ActionResult Trash()
        {
            ViewBag.Isactive = 65;
            int user = Statics.GetUser().ID;
            List<Message> trashMsgList = virames<Message>.Initialize(new List<Message>())
                           .Where(x => ((x.SenderID == user && x.OwnerID == user) || (x.ReceiverID == user && x.OwnerID == user)) && x.MessageLocationType == MessageLocationType.Garbage)
                           .GetList();
            return View(trashMsgList);
        }
    }
}