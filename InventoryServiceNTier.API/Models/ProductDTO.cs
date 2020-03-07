using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InventoryServiceNTier.API.Models
{
    public class ProductDTO
    {
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
