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

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Available")] Product product)
        {
            return UnboundCreate(product);
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
