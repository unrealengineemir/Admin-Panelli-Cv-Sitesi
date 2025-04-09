using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();

        [Authorize]
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
        public ActionResult Add(TBL_EDUCATİON e)
        {
            if (!ModelState.IsValid)
            {

                return View();

            }

            repo.Tadd(e);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            TBL_EDUCATİON d = repo.IFind(x => x.ID == id);
            repo.Tdelete(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            TBL_EDUCATİON e = repo.IFind(x => x.ID == id);
            return View(e);

        }

        [HttpPost]
        public ActionResult Update(TBL_EDUCATİON e)
        {
         

            TBL_EDUCATİON ed = repo.IFind(x => x.ID == e.ID);
            ed.TİTLE = e.TİTLE;
            ed.SUBTİTLE1 = e.SUBTİTLE1;
            ed.SUBTİTLE2 = e.SUBTİTLE2;
            ed.GNO = e.GNO;
            ed.DATE = e.DATE;


            if (!ModelState.IsValid)
            {

                return View();

            }


            repo.Tupdate(ed);
            return RedirectToAction("Index");


        }



    }
}