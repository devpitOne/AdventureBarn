using System.Collections.Generic;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A quantity of products
    /// </summary>
    public class Stock
    {
        public long Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual IEnumerable<Shelf> Locations { get; set; }

        public long Quantity { get; set; }
    }
}
