using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        GenericRepository<TBL_MEDİA> repo = new GenericRepository<TBL_MEDİA>();
        CvDatabaseEntities db = new CvDatabaseEntities();

        public ActionResult Index(TBL_MEDİA m)
        {
            var list = db.TBL_MEDİA.Where(x => x.Situation == true).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBL_MEDİA m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.Tadd(m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var update = repo.IFind(m => m.ID == id);
            return View(update);
        }

        [HttpPost]
        public ActionResult Update(TBL_MEDİA m)
        {
            var update = repo.IFind(x => x.ID == m.ID);
            update.NAME = m.NAME;
            update.LİNK = m.LİNK;
            update.İCON = m.İCON;
            update.Situation = true;
            repo.Tupdate(update);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var del = repo.IFind(x => x.ID == id);
            del.Situation = false;
            repo.Tupdate(del);
            return RedirectToAction("Index");

        }
    }
}