using AdventureBarn.Contracts.Models;
using AdventureBarn.Contracts.Repositories;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AdventureBarn.WorkSite.Controllers
{
    public class AddressController : GenericController<Address>
    {

        public AddressController(IGenericRepository<Address> repository): base(repository)
        {
        }

        // POST: Address/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Country,Postcode")] Address address)
        {
            return UnboundCreate(address);
        }


        // POST: Address/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddressLine1,AddressLine2,AddressLine3,AddressLine4,Country,Postcode")] Address address)
        {
            return UnboundEdit(address);
        }

    }
}
