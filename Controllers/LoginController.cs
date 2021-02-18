using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using viramesV4.Cloud.Models;
using viramesV4.Object.BusinessLogicLayer.System;
using viramesV4.Object.Factory;
using viramesV4.Object.HelperLayer;

namespace viramesV4.Cloud.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string ReturnUrl)
        {
            if (ReturnUrl != null)
                Session["UrlReferer"] = ReturnUrl;
            LoginModel loginModel = new LoginModel();
            loginModel.Username = "virames";
            ViewBag.Workareas = virames<Workarea>.InitializeList(new List<Workarea>()).Where(x => x.Status == Object.HelperLayer.RecordStatus.Active).GetList();
            return View(loginModel);

        }

        [HttpPost]
        public ActionResult LoginDo(LoginModel model)
        {
            User currentUser = virames<User>.Initialize(new User()).Where(x => x.Username == model.Username).Take();
            
            if (currentUser != null && currentUser.Password == Functions.MD5(model.Password))
            {
                Statics.SetUser(currentUser);
                Workarea currentWorkarea = virames<Workarea>.Initialize(new Workarea()).Where(x => x.ID == model.Workarea).Take();
                if (currentWorkarea != null)
                    Statics.SetWorkarea(currentWorkarea);
            }
            string url = "/";
            if (Session["UrlReferer"] != null)
                url = Session["UrlReferer"].ToString();
            return Redirect(url);

        }

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Statics.SetUser(null);
            Statics.SetWorkarea(null);
            return RedirectToAction("Index", "Login");
        }
        
    }
}