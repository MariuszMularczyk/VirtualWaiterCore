using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DessertController : ControllerBase
    {

        private readonly IProductService _productService;

        public DessertController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public void Add(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model, ProductType.Dessert);
            }
        }

        [HttpGet("getDesserts")]
        public List<ProductListDTO> GetProducts()
        {
            return _productService.GetProducts(ProductType.Dessert);
        }
        [HttpGet("getDessert/{id}")]
        public ProductEditVM GetDessert(int id)
        {
            return _productService.GetProduct(id);
        }
        [HttpPost("edit")]
        public void Edit(ProductEditVM model)
        {
            _productService.Edit(model);
        }
        [HttpDelete("deleteDessert/{id}")]
        public void DessertDrink(int id)
        {
            _productService.Delete(id);
        }
    }
}
