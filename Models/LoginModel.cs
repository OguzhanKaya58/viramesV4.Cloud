using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using viramesV4.Object.BusinessLogicLayer.System;

namespace viramesV4.Cloud.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Workarea { get; set; }
    }
}