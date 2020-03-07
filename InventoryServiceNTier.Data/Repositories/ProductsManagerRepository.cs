using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InventoryServiceNTier.Data.Entities;
using InventoryServiceNTier.Data.Interfaces;

namespace InventoryServiceNTier.Data.Repositories
{
    public class ProductsManagerRepository: IProductsManagerRepository
    {
        private readonly InventoryContext _context;
        public ProductsManagerRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<Products> GetAllProducts()
        {
            try
            {
                List<Products> prodList = _context.Products.ToList();
                return prodList;
            }
            catch(Exception ex)
            {
                throw ex;
                //FAIL SILENTLY BUT ADD SOMETHING TO HANDLE LATER
            }
        }
    }
}
