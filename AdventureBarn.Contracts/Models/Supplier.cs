using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A supplier and source of a particular product
    /// </summary>
    public class Supplier
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Address BusinessAddress { get; set; }
    }
}
