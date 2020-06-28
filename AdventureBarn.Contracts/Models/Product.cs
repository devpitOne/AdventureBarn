using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A product sourced from a supplier
    /// </summary>
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Available { get; set; }

        public Supplier Supplier { get; set; }
    }
}
