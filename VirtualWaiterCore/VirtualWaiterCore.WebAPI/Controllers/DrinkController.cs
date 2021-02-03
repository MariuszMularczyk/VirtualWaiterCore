﻿using System;
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
    public class DrinkController : ControllerBase
    {

        private readonly IProductService _productService;

        public DrinkController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public void Add(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model, ProductType.Drink);
            }
        }
        
        [HttpGet("getDrinksToMenu")]
        public List<ProductListDTO> GetProductsToMenu()
        {
            return _productService.GetProductsToMenu(ProductType.Drink);
        }
        [HttpGet("getDrinks")]
        public List<ProductListDTO> GetProducts()
        {
            return _productService.GetProducts(ProductType.Drink);
        }
        [HttpGet("getDrink/{id}")]
        public ProductEditVM GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }
        [HttpPost("edit")]
        public void Edit(ProductEditVM model)
        {
            _productService.Edit(model);
        }
        [HttpDelete("deleteDrink/{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
