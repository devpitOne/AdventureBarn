using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
