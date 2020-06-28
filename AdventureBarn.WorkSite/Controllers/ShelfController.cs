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
    public class ShelfController : GenericController<Shelf>
    {

        public ShelfController(IGenericRepository<Shelf> repository) : base(repository)
        {            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Shelf shelf)
        {
            return UnboundCreate(shelf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Shelf shelf)
        {
            return UnboundEdit(shelf);
        }
    }
}
