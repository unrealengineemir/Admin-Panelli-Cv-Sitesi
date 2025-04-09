using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        CvDatabaseEntities db = new CvDatabaseEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_ABOUT.ToList();
            return View(degerler);
        }

        public PartialViewResult Experience()
        {
            var degerler = db.TBL_EXPERİENCES.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Education()
        {
            var degerler = db.TBL_EDUCATİON.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Skill()
        {
            var degerler = db.TBL_SKİLL.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult İnterest()
        {
            var degerler = db.TBL_İNTEREST.ToList();
            return PartialView(degerler);

        }

        public PartialViewResult Certificates()
        {

            var degerler = db.TBL_CERTIFICATES.ToList();
            return PartialView(degerler);

        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(TBL_COMMUNİCATİON c)
        {

            c.DATE = DateTime.Parse(DateTime.Now.ToLongDateString());
            db.TBL_COMMUNİCATİON.Add(c);
            db.SaveChanges();
            return PartialView();


        }

        public PartialViewResult Media(TBL_MEDİA m)
        {
            var media = db.TBL_MEDİA.ToList();
            return PartialView(media);
        }


    }
}