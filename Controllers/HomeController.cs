using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viramesV4.Cloud.Helpers;

namespace viramesV4.Cloud.Controllers
{
    public class HomeController : Controller
    {
        [ViramesAuthorization]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}