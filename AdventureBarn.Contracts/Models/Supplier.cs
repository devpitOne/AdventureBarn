using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A supplier and source of a particular product
    /// </summary>
    public class Supplier
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long BusinessAddressId { get; set; }

        [DisplayName("Business Address")]
        public virtual Address BusinessAddress { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
