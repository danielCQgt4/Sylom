using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessinTest.Models {
    public class CyCAuth : AuthorizeAttribute {

        public override void OnAuthorization(AuthorizationContext filterContext) {
            if (!filterContext.HttpContext.Request.RawUrl.Equals("/about")) {
                filterContext.Result = new RedirectResult("/index");
            }
        }
    }

}