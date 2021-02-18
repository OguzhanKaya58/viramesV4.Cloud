using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viramesV4.Object.BusinessLogicLayer.System;
using viramesV4.Object.HelperLayer;

namespace viramesV4.Cloud.Helpers
{
    public class ViramesAuthorization : AuthorizeAttribute
    {
        public string ActionCode = "<>";

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User currentUser = Statics.GetUser();
            if (currentUser == null || currentUser.ID == 0)
            {
                httpContext.Response.Redirect("/Login/?ReturnUrl=" + httpContext.Request.Url.AbsolutePath);
                return false;
            }

            return true;
        }
    }
}