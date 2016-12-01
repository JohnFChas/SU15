using MVCCMS.EntityFramework.Repositories;
using MVCCMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCMS.Controllers
{
    public class ProductsController : Controller
    {
        IStoreRepository repository;

        public ProductsController()
        {
            repository = new DbStoreRepository();
        }

        public ProductsController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        // GET: Products
        public ActionResult Index()
        {
            var model = repository.GetProducts();
            return View(model);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!repository.CreateProduct(model))
                return RedirectToAction("Index");

            return View("Index", model);
        }

        // GET: Products/Edit/{id}
        public ActionResult Edit(int id)
        {
            var model = repository.GetProduct(id);
            return View(model);
        }

        // POST: Products/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.UpdateProduct(model);

            return RedirectToAction("Index");
        }

        // GET: Products/Details/{id}
        public ActionResult Details(int id)
        {
            var model = repository.GetProduct(id);
            return View(model);
        }

        // GET: Products/Delete/{id}
        public ActionResult Delete(int id)
        {
            var model = repository.GetProduct(id);
            return View(model);
        }

        // POST: Products/Delete{id}
        [HttpPost]
        public ActionResult Delete(int id, Product model)
        {
            if (id != model.Id)
            {
                ModelState.AddModelError("Name", "Bad request");
                return View(model);
            }

            repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        // The Dispose method is called when the HTTP-response has been sent, we use this
        // to also dispose of our database connection.
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}