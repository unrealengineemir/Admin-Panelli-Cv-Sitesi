using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        ExperienceRepository repo = new ExperienceRepository();
       
        public ActionResult Index()
        {
            var deneyimler = repo.List();
            return View(deneyimler);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]       
        public ActionResult Add(TBL_EXPERİENCES t)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }


            repo.Tadd(t);
            return RedirectToAction("Index");

        }

       
        public ActionResult Delete(int id)
        {

            TBL_EXPERİENCES t = repo.IFind(x=>x.ID==id);
            repo.Tdelete(t);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            TBL_EXPERİENCES t = repo.IFind(x=>x.ID ==id);
            return View(t);

        }

        [HttpPost]
        public ActionResult Update(TBL_EXPERİENCES p)
        {
            TBL_EXPERİENCES t = repo.IFind(x=>x.ID==p.ID);
            t.TİTLE = p.TİTLE;
            t.SUBTİTLE = p.SUBTİTLE;
            t.DATE = p.DATE;
            t.DESCRİPTİON = p.DESCRİPTİON;

            if (!ModelState.IsValid)
            {
                return View();
            }


            repo.Tupdate(t);
            return RedirectToAction("Index");

        }


    }
}