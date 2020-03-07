using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.API.Models;

namespace InventoryServiceNTier.API.Messages
{
    public class ProductResponse
    {
        public List<ProductDTO> products { get; set; }
        public ProductDTO product { get; set; }
    }
}
