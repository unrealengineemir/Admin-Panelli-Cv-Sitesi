using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates

        CertificatesRepository repo = new CertificatesRepository();

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
        public ActionResult Add(TBL_CERTIFICATES c)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            repo.Tadd(c);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TBL_CERTIFICATES c = repo.IFind(x => x.ID == id);
            repo.Tdelete(c);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            TBL_CERTIFICATES c = repo.IFind(x => x.ID == id);

            return View(c);

        }

        [HttpPost]

        public ActionResult Update(TBL_CERTIFICATES t)
        {
            TBL_CERTIFICATES c = repo.IFind(x => x.ID == t.ID);
            c.DESCRİPTİON = t.DESCRİPTİON;
            c.DATE = t.DATE;

            if (!ModelState.IsValid) 
            {

                return View();
            
            }

            repo.Tupdate(c);
            return RedirectToAction("Index");

        }



    }
}