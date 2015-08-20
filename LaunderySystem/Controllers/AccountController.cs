using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LaunderySystem.Models;
using LaunderySystem.CustomIdentity;
using System.Web.Script.Serialization;
using LaunderySystem.Services;
using LaunderySystem.ModelView;

namespace LaunderySystem.Controllers
{
    [Authorize] 
    public class AccountController : Controller
    {
        //public static bool logedin;
        private readonly UserService _usrService;
        private readonly LaunderyService _ldryService;
        private readonly EmailServices _emailService;



        LaunderyContext db = new LaunderyContext();
        //
        // GET: /Account/

        public AccountController()
        {
            _usrService = new UserService(db);
            _ldryService = new LaunderyService(db);
            _emailService = new EmailServices(db);
        }
       
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
            
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["user"].ToString();
            string password = form["pass"].ToString();
            var usr = _usrService.GetUserProfile(username, password);

            if (usr==null)
            {
                TempData["Message"] = "Fel användarnamn och/eller lösenord";
                return View();
            }
            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.Id = usr.Id;
            serializeModel.FirstName = usr.FirstName;
            serializeModel.LastName = usr.LastName;
            serializeModel.Adress = usr.LaunderyRoom.Adress;
            serializeModel.LaunderyAdress = usr.LaunderyRoom.Adress;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
             1,
             username,
             DateTime.Now,
             DateTime.Now.AddMinutes(15),
             false,
             userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);

            return RedirectToAction("Index", "Dashboard");
            
        }
      

        //public ActionResult AddUser()
        //{
        //    ViewBag.LaunderyRoom = db.LaunderyRoom;
        //    return View();
        //}

        //public ActionResult Adminindex()
        //{
        //    var dropdownlistLaundery = _usrService.GetUserProfiles();

        //    return View(dropdownlistLaundery);
        //}

        //[HttpPost]
        //public ActionResult AddUser(UserProfile userprofile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _usrService.CreateUserProfil(userprofile);
        //    }
        //    return RedirectToAction("Adminindex");
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword(string recoverykey)
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(FormCollection form)
        {
            string email = form["email"].ToString();
            var usr = _usrService.GetUserProfile(email);

            if (ModelState.IsValid)
            {
                if (usr == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("Login");
                }
                string passwordKey = KeyGenerator.GetUniqueKey(8);
                usr.PassWord = passwordKey;
                _usrService.SaveUserProfil(usr);
                string message = _emailService.ForgotPasswordContent(usr.PassWord);
                _emailService.SendEmail(usr.Email, "Password Recovery", message);

                return RedirectToAction("ForgotPassword", "Account");
            }


            // If we got this far, something failed, redisplay form
            return View("Login");
        }

    }
}
