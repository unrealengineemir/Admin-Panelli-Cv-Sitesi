using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        SkillRepository repo = new SkillRepository();

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
        public ActionResult Add(TBL_SKİLL s)
        {

            if (!ModelState.IsValid)
            {

                return View();

            }

            repo.Tadd(s);
            return RedirectToAction("Index");


        }

        public ActionResult Delete(int id)
        {
            var s = repo.IFind(x => x.ID == id);
            repo.Tdelete(s);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var update = repo.IFind(x=>x.ID==id);
            return View(update);

        }

        [HttpPost]
        public ActionResult Update(TBL_SKİLL s)
        {
            var update = repo.IFind(x=>x.ID==s.ID);
            update.SKİLL = s.SKİLL;
            update.DEGREE = s.DEGREE;

            if (!ModelState.IsValid)
            {

                return View();

            }

            repo.Tupdate(update);
            return RedirectToAction("Index");

        }

    }

}