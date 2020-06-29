using System.ComponentModel.DataAnnotations;

namespace AdventureBarn.Contracts.Models
{
    /// <summary>
    /// A shelf, a physical location where products are stored
    /// </summary>
    public class Shelf
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
