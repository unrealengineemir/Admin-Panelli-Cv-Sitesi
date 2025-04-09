using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class İnterestController : Controller
    {
        // GET: İnterest

        İnterestRepository repo = new İnterestRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(TBL_İNTEREST i)
        {
            var update = repo.IFind(x => x.ID == 1);
            update.DESCRİPTİON1 = i.DESCRİPTİON1;
            update.DESCRİPTİON2 = i.DESCRİPTİON2;

            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.Tupdate(update);
            return RedirectToAction("Index");
        }



    }
}