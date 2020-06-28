using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A shelf, a physical location where products are stored
    /// </summary>
    public class Shelf
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
