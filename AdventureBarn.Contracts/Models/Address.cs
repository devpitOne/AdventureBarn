using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// An Address, may be a business address or a shipping address
    /// </summary>
    public class Address
    {
        public long Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string Country { get; set; }

        public string Postcode { get; set; }
    }
}
