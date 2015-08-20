using LaunderySystem.Attributes;
using LaunderySystem.CustomIdentity;
using LaunderySystem.Models;
using LaunderySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LaunderySystem.Controllers
{
    [Authorize]
    public class Nz77jh92Controller : BaseController
    {
        private readonly NewsService _newsService;
        private readonly UserService _usrService;
        private readonly LaunderyService _ldryService;
        private readonly AdminService _adminService;
        LaunderyContext db = new LaunderyContext();


        public Nz77jh92Controller()
        {
            _adminService = new AdminService(db);
            _usrService = new UserService(db);
            _ldryService = new LaunderyService(db);
            _newsService = new NewsService(db);
        }
        public bool IsAdmin()
        {
            if (User.Role=="Admin")
	        {
                return true;
	        }
            else
            {
                return false;
            } 
        }

        public ActionResult Index()
        {
            if(IsAdmin()!=true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public ActionResult News()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var dropdownNews = _newsService.GetNewsToList();

            return View(dropdownNews);
        }       

        public ActionResult CreateNews()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.LaunderyRoom = db.LaunderyRoom;
            return View();
        }

        [HttpPost]
        public ActionResult CreateNews(News news)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            try
            {
                news.DateAndTime = DateTime.Now.ToString();
                _newsService.CreateNews(news);
                return RedirectToAction("News");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditNews(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = _newsService.GetNews(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaunderyRoom = db.LaunderyRoom;
            return View(news);
        }

        [HttpPost]
        public ActionResult EditNews(News news)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _newsService.SaveNews(news);
                    return RedirectToAction("News");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteNews(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = _newsService.GetNews(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaunderyRoom = db.LaunderyRoom;
            return View(news);
        }

        [HttpPost, ActionName("DeleteNews")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteNews(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                _newsService.DeleteNews(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult UserList()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var dropdownUserList = _usrService.GetUserProfiles();

            return View(dropdownUserList);
        }

        public ActionResult LaunderyList()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var dropdownLaunderyList = _ldryService.GetLaunderyToList();

            return View(dropdownLaunderyList);
        }

        public ActionResult CreateUser()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.LaunderyRoom = db.LaunderyRoom;
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreateUser(UserProfile userprofile)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _usrService.CreateUserProfil(userprofile);
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateLaundery(LaunderyRoom launderyRoom)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _ldryService.CreateLaundery(launderyRoom);
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateLaundery()
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditUser(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserProfile user = _usrService.GetUserProfile(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaunderyRoom = db.LaunderyRoom;
            return View(user);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditUser(UserProfile userprofile)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _usrService.SaveUserProfil(userprofile);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditLaundery(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LaunderyRoom launderyroom = _ldryService.GetLaundery(id);
            if (launderyroom == null)
            {
                return HttpNotFound();
            }
            return View(launderyroom);
        }


        [HttpPost]
        public ActionResult EditLaundery(LaunderyRoom launderyRoom)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _ldryService.SaveLaundery(launderyRoom);
                    return RedirectToAction("LaunderyList");
                }

                return RedirectToAction("EditLaundery");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteUser(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserProfile user = _usrService.GetUserProfile(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteUser(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                _usrService.DeleteUserProfil(id);

                return RedirectToAction("UserList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteLaundery(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LaunderyRoom launderyroom = _ldryService.GetLaundery(id);
            if (launderyroom == null)
            {
                return HttpNotFound();
            }
            return View(launderyroom);
        }

        
        [HttpPost, ActionName("DeleteLaundery")]
        public ActionResult ConfirmDeleteLaundery(int? id)
        {
            if (IsAdmin() != true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return RedirectToAction("LaunderyList");
            }
            catch
            {
                return View();
            }
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
            var usr = (from u in db.UserProfile
                       where u.UserName == username && u.PassWord == password
                       select u).FirstOrDefault();
            if (usr == null)
            {
                TempData["Message"] = "Fel användarnamn och/eller lösenord";
                return View();
            }
            string s = _adminService.GetAdmin(usr.Id);
            if (s==null)
            {
                TempData["Message"] = "You do not have access to this page!";
                return View();
            }
            

            
            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.Id = usr.Id;
            serializeModel.FirstName = usr.FirstName;
            serializeModel.LastName = usr.LastName;
            serializeModel.Adress = usr.Adress;
            serializeModel.LaunderyAdress = usr.LaunderyRoom.Adress;
            serializeModel.Role = s;
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

            return RedirectToAction("Index", "Nz77jh92");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
