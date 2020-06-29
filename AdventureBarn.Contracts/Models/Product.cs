using System.ComponentModel.DataAnnotations;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A product sourced from a supplier
    /// </summary>
    public class Product
    {
        #region Properties
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Available { get; set; }

        public long SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        #endregion
    }
}
