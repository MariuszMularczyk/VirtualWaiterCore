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
    public class AppetizerController : ControllerBase
    {

        private readonly IProductService _productService;

        public AppetizerController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public void Add(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model, ProductType.Appetizer);
            }
        }

        [HttpGet("getAppetizers")]
        public List<ProductListDTO> GetDrinks()
        {
            return _productService.GetProducts(ProductType.Appetizer);
        }
        [HttpGet("getAppetizersToMenu")]
        public List<ProductListDTO> GetDrinksToMenu()
        {
            return _productService.GetProductsToMenu(ProductType.Appetizer);
        }
        [HttpGet("getAppetizer/{id}")]
        public ProductEditVM GetDrink(int id)
        {
            return _productService.GetProduct(id);
        }
        [HttpPost("edit")]
        public void Edit(ProductEditVM model)
        {
            _productService.Edit(model);
        }

        [HttpDelete("deleteAppetizer/{id}")]
        public void DeleteAppetizer(int id)
        {
            _productService.Delete(id);
        }
    }
}
