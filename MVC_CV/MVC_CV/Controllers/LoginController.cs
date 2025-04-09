using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        CvDatabaseEntities db = new CvDatabaseEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBL_ADMİN m)
        {

            var userinfo = db.TBL_ADMİN.FirstOrDefault(x => x.USERNAME == m.USERNAME && x.PASSWORD == m.PASSWORD);

            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.USERNAME, false);
                Session["USERNAME"] = userinfo.USERNAME.ToString();
                return RedirectToAction("Index", "Experience");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
           
        }
    }
}