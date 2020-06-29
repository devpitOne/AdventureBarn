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
        #region Properties
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Available { get; set; }

        public long SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        #endregion
    }
}
