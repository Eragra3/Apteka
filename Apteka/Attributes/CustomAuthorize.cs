using Apteka.Helpers;
using ClientLogic.Models;
using Common;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apteka.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ISessionManager _sessionManager = new SessionManager();

        public CustomAuthorizeAttribute()
        {
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var loggedIn = _sessionManager.IsSet("User");
            return loggedIn;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}