using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viramesV4.Cloud.Helpers;
using viramesV4.Object.BusinessLogicLayer.Master;
using viramesV4.Object.BusinessLogicLayer.System;
using viramesV4.Object.Factory;
using viramesV4.Object.HelperLayer;
using Log = viramesV4.Object.BusinessLogicLayer.System.Log;

namespace viramesV4.Cloud.Controllers
{
    [ViramesAuthorization]
    public class SystemManagementController : Controller
    {

        #region Master Records

        #region Role
        [HttpGet]
        public ActionResult Role()
        {
            ViewBag.Isactive = 80;
            List<Role> roleList = virames<Role>
                             .Initialize(new List<Role>())
                             .GetList();
            return View(roleList);
        }
        [HttpGet]
        public ActionResult NewRole()
        {
            ViewBag.UserType = new SelectList(Enum.GetValues(typeof(UserType)));
            Role role = new Role();
            return View(role);
        }
        [HttpPost]
        public ActionResult NewRole(Role role)
        {
            role.Save();
            return RedirectToAction("Role");
        }
        [HttpGet]
        public ActionResult EditRole(int ID)
        {
            ViewBag.UserType = new SelectList(Enum.GetValues(typeof(UserType)));
            Role role = virames<Role>
                             .Initialize(new Role()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(role);
        }
        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            role.Save();
            return RedirectToAction("Role");
        }
        [HttpGet]
        public ActionResult DetailRole(int ID)
        {
            Role role = virames<Role>
                            .Initialize(new Role()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(role);
        }
        [HttpPost]
        public ActionResult DetailRole(Role role)
        {
            role.Save();
            return RedirectToAction("Role");
        }
        [HttpGet]
        public ActionResult DeleteRole(int ID)
        {
            Role role = virames<Role>
                           .Initialize(new Role()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(role);

        }
        [HttpPost]
        public ActionResult DeleteRole(Role role)
        {
            role.Delete();
            return RedirectToAction("Role");
        }
        #endregion

        #region User
        [HttpGet]
        public new ActionResult User()
        {
            ViewBag.Isactive = 81;
            List<User> usrList = virames<User>
                            .Initialize(new List<User>())
                            .GetList();
            return View(usrList);
        }
        [HttpGet]
        public ActionResult NewUser()
        {
            ViewBag.User = virames<Role>.Initialize(new List<Role>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name + " | " + x.UserType
            });
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult NewUser(User user)
        {
            user.Save();
            return RedirectToAction("User");
        }
        [HttpGet]
        public ActionResult EditUser(int ID)
        {
            ViewBag.User = virames<Role>.Initialize(new List<Role>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name + " | " + x.UserType
            });
            User user = virames<User>
                             .Initialize(new User()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            user.Save();
            return RedirectToAction("User");
        }
        [HttpGet]
        public ActionResult DetailUser(int ID)
        {
            User user = virames<User>
                            .Initialize(new User()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(user);
        }
        [HttpPost]
        public ActionResult DetailUser(User user)
        {
            user.Save();
            return RedirectToAction("User");
        }
        [HttpGet]
        public ActionResult DeleteUser(int ID)
        {
            User user = virames<User>
                           .Initialize(new User()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(user);

        }
        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            user.Delete();
            return RedirectToAction("User");
        }
        [HttpGet]
        public ActionResult EditPassword(int ID)
        {
            User user = virames<User>
                               .Initialize(new User()).Where(x => x.ID.ToString() == ID.ToString())
                               .Take();
            return View(user);
        }
        [HttpPost]
        public ActionResult SetEditPassword(int Id)
        {

            User user = virames<User>
                               .Initialize(new User()).Where(x => x.ID.ToString() == Id.ToString())
                               .Take();
            user.Password = Functions.MD5(Session["NewPassword"].ToString());
            user.Save();
            return RedirectToAction("User");
        }
        #endregion

        #region WorkArea
        [HttpGet]
        public ActionResult WorkArea()
        {
            ViewBag.Isactive = 82;
            List<Workarea> waList = virames<Workarea>
                             .Initialize(new List<Workarea>())
                             .GetList();
            return View(waList);
        }
        [HttpGet]
        public ActionResult NewWorkArea()
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.Currency = virames<Workarea>
                          .Initialize(new List<Workarea>())
                          .GetList().Select(x => new SelectListItem
                          {
                              Value = x.ID.ToString(),
                              Text = x.Currency.Name + " | " + x.Currency.Symbol
                          });
            Workarea workarea = new Workarea();
            return View(workarea);
        }
        [HttpPost]
        public ActionResult NewWorkArea(Workarea workarea)
        {
            workarea.Save();
            return RedirectToAction("WorkArea");
        }
        [HttpGet]
        public ActionResult EditWorkArea(int ID)
        {
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(Status)));
            ViewBag.Currency = virames<Workarea>.Initialize(new List<Workarea>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Currency.Name + " | " + x.Currency.Symbol
            });
            Workarea workarea = virames<Workarea>
                             .Initialize(new Workarea()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(workarea);
        }
        [HttpPost]
        public ActionResult EditWorkArea(Workarea workarea)
        {
            workarea.Save();
            return RedirectToAction("WorkArea");
        }
        [HttpGet]
        public ActionResult DeleteWorkArea(int ID)
        {
            Workarea workarea = virames<Workarea>
                           .Initialize(new Workarea()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(workarea);

        }
        [HttpPost]
        public ActionResult DeleteWorkArea(Workarea workarea)
        {
            workarea.Delete();
            return RedirectToAction("WorkArea");
        }
        #endregion

        #region Terminal
        [HttpGet]
        public ActionResult Terminal()
        {
            ViewBag.Isactive = 83;
            List<Terminal> terminal = virames<Terminal>
                             .Initialize(new List<Terminal>())
                             .GetList();
            return View(terminal);
        }
        [HttpGet]
        public ActionResult NewTerminal()
        {
            ViewBag.User = virames<User>.Initialize(new List<User>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Username + " | " + x.Name + " | " + x.Role + " | " + x.Password
            });
            Terminal terminal = new Terminal();
            return View(terminal);
        }
        [HttpPost]
        public ActionResult NewTerminal(Terminal terminal)
        {
            terminal.Save();
            return RedirectToAction("Terminal");
        }
        [HttpGet]
        public ActionResult EditTerminal(int ID)
        {
            ViewBag.User = virames<User>.Initialize(new List<User>()).GetList().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Username + " | " + x.Name + " | " + x.Role + " | " + x.Password
            });
            Terminal terminal = virames<Terminal>
                             .Initialize(new Terminal()).Where(x => x.ID.ToString() == ID.ToString())
                             .Take();
            return View(terminal);
        }
        [HttpPost]
        public ActionResult EditTerminal(Terminal terminal)
        {
            terminal.Save();
            return RedirectToAction("Terminal");
        }
        [HttpGet]
        public ActionResult DetailTerminal(int ID)
        {
            Terminal terminal = virames<Terminal>
                            .Initialize(new Terminal()).Where(x => x.ID.ToString() == ID.ToString())
                            .Take();
            return View(terminal);
        }
        [HttpPost]
        public ActionResult DetailTerminal(Terminal terminal)
        {
            terminal.Save();
            return RedirectToAction("Terminal");
        }
        [HttpGet]
        public ActionResult DeleteTerminal(int ID)
        {
            Terminal terminal = virames<Terminal>
                           .Initialize(new Terminal()).Where(x => x.ID.ToString() == ID.ToString())
                           .Take();
            return View(terminal);

        }
        [HttpPost]
        public ActionResult DeleteTerminal(Terminal terminal)
        {
            terminal.Delete();
            return RedirectToAction("Terminal");
        }
        #endregion

        #region ReportDesign 
        [HttpGet]
        public ActionResult ReportDesign()
        {
            ViewBag.Isactive = 84;
            List<ReportDesign> reportDesignList = virames<ReportDesign>
                             .Initialize(new List<ReportDesign>())
                             .GetList();
            return View(reportDesignList);
        }
        #endregion
        #endregion



        [HttpGet]
        public ActionResult UserAuthorizations()
        {
            ViewBag.Isactive = 85;
            List<UserAuthorization> uaList = virames<UserAuthorization>
                             .Initialize(new List<UserAuthorization>())
                             .GetList();
            return View(uaList);
        }
        [HttpGet]
        public ActionResult LayOut()
        {
            ViewBag.Isactive = 86;
            List<Layout> layout = virames<Layout>
                .Initialize(new List<Layout>())
                .GetList();
            return View(layout);
        }
        [HttpGet]
        public ActionResult LockedObject()
        {
            ViewBag.Isactive = 87;
            List<LockedObject> LockedObjectList = virames<LockedObject>
                               .Initialize(new List<LockedObject>())
                               .GetList();
            return View(LockedObjectList);
        }
        [HttpGet]
        public ActionResult Log()
        {
            ViewBag.Isactive = 88;
            List<Log> logList = virames<Log>
                             .Initialize(new List<Log>())
                             .GetList();
            return View(logList);
        }
        [HttpGet]
        public ActionResult RoleAuthorization()
        {
            ViewBag.Isactive = 89;
            List<RoleAuthorization> uaList = virames<RoleAuthorization>
                             .Initialize(new List<RoleAuthorization>())
                             .GetList();
            return View(uaList);
        }

    }
}