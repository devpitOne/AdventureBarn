using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;

namespace AdventureBarn.WorkSite.Controllers
{
    public class SupplierController : GenericController<Supplier>
    {
        public SupplierController(IGenericRepository<Supplier> repository) : base(repository)
        {
        }

        public override ActionResult Create()
        {
            var newSupplier = new Supplier { BusinessAddress = new Address() };
            return View(newSupplier);
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BusinessAddress")] Supplier supplier)
        {
            return UnboundCreate(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BusinessAddress,BusinessAddressId")] Supplier supplier)
        {
            var controller = DependencyResolver.Current.GetService<AddressController>();
            controller.ControllerContext = new ControllerContext(Request.RequestContext, controller);
            controller.Edit(supplier.BusinessAddress);
            return UnboundEdit(supplier);
        }

        public List<Supplier> GetSupplierList()
        {
            return _repository.GetAll().ToList();
        }
    }
}
