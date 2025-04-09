using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TBL_ADMİN> repo = new GenericRepository<TBL_ADMİN>();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBL_ADMİN ad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.Tadd(ad);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var bul = repo.IFind(x => x.ID == id);
            return View(bul);

        }

        [HttpPost]
        public ActionResult Update(TBL_ADMİN ad)
        {

            var bul = repo.IFind(x => x.ID == ad.ID);
            bul.USERNAME = ad.USERNAME;
            bul.PASSWORD = ad.PASSWORD;

            if (!ModelState.IsValid) 
            {
                return View();
            }

            repo.Tupdate(bul);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var bul = repo.IFind(x => x.ID == id);
            repo.Tdelete(bul);
            return RedirectToAction("Index");
        }

    }
}