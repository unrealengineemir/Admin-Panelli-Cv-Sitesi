using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communication

        GenericRepository<TBL_COMMUNİCATİON> repo = new GenericRepository<TBL_COMMUNİCATİON>();


        public ActionResult Index()
        {
            var communication = repo.List();
            return View(communication);
        }





    }
}