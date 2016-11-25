using MVCCMS.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCMS.Controllers
{
    public class HomeController : Controller
    {
        IStoreRepository repository;

        public HomeController()
        {
            repository = new DbStoreRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}