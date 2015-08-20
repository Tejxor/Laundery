using LaunderySystem.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunderySystem.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        
            protected virtual new CustomPrincipal User
            {
                get { return HttpContext.User as CustomPrincipal; }
            }

    }

    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}
