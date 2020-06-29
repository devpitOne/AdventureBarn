using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventureBarn.WorkSite.Controllers
{
    public class ProductController : GenericController<Product>
    {
        public ProductController(IGenericRepository<Product> repository) : base(repository)
        {
        }

        // An override of the default create to allow us to change default available property value.
        public override ActionResult Create()
        {
            var controller = DependencyResolver.Current.GetService<SupplierController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);
            ViewBag.Suppliers = controller.GetSupplierList();
            var newProduct = new Product { Available = true };
            return View(newProduct);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Available,SupplierId")] Product product)
        {
            return UnboundCreate(product);
        }

        public override ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var foundObject = _repository.GetByID(id.Value);
            if (foundObject == null)
            {
                return HttpNotFound();
            }
            var controller = DependencyResolver.Current.GetService<SupplierController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);
            ViewBag.Suppliers = controller.GetSupplierList();
            return View(foundObject);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Available")] Product product)
        {
            return UnboundEdit(product);
        }

    }
}
