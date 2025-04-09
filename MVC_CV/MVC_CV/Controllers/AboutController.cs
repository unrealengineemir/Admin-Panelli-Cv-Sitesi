using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutRepository repo = new AboutRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(TBL_ABOUT a)
        {
            var ab = repo.IFind(x=>x.ID==1);
            ab.NAME = a.NAME;
            ab.SURNAME = a.SURNAME;
            ab.ADRESS = a.ADRESS;
            ab.TELEPHONE = a.TELEPHONE;
            ab.MAİL = a.MAİL;
            ab.DESCRİPTİON = a.MAİL;
            ab.İMAGE = a.İMAGE;


            if (!ModelState.IsValid) 
            {

                return View();
            }

            repo.Tupdate(ab);
            return RedirectToAction("Index");
        }

    }
}