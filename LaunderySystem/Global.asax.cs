using LaunderySystem.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LaunderySystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
                if (serializeModel==null)
                {
                    HttpContext.Current.User = null;
                }
                else
                {
                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.Id = serializeModel.Id;
                    newUser.FirstName = serializeModel.FirstName;
                    newUser.LastName = serializeModel.LastName;
                    newUser.Adress = serializeModel.Adress;
                    newUser.LaunderyAdress = serializeModel.LaunderyAdress;
                    newUser.Role = serializeModel.Role;

                    HttpContext.Current.User = newUser;
                }
            }
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
    
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}