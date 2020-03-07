using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using InventoryServiceNTier.Data.Interfaces;
using InventoryServiceNTier.Data.Repositories;
using InventoryServiceNTier.API.Messages;
using InventoryServiceNTier.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace InventoryServiceNTier.API.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductsManagerRepository _products;

        public ProductController(IMapper mapper, IProductsManagerRepository products)
        {
            _mapper = mapper;
            _products = products;
        }

        [HttpGet]
        [Route("api/GetProducts")]
        public ProductResponse GetProducts()
        {
            List<ProductDTO> productList = _mapper.Map <List<ProductDTO>>(_products.GetAllProducts());
            ProductResponse resp = new ProductResponse()
            {
                products = productList
            };
            return resp;
        }
    }
}