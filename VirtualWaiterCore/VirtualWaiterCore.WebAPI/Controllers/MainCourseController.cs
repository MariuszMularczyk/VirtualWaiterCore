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
    public class MainCourseController : ControllerBase
    {

        private readonly IProductService _productService;

        public MainCourseController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public void Add(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model, ProductType.MainCourse);
            }
        }
        
        [HttpGet("getMainCourses")]
        public List<ProductListDTO> GetMainCourses()
        {
            return _productService.GetProducts(ProductType.MainCourse);
        }
        [HttpGet("getMainCoursesToMenu")]
        public List<ProductListDTO> GetMainCoursesToMenu()
        {
            return _productService.GetProductsToMenu(ProductType.MainCourse);
        }
        [HttpGet("getMainCourse/{id}")]
        public ProductEditVM GetMainCourse(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost("edit")]
        public void Edit(ProductEditVM model)
        {
            _productService.Edit(model);
        }

        [HttpDelete("deleteMainCourse/{id}")]
        public void DeleteMainCourse(int id)
        {
            _productService.Delete(id);
        }
    }
}
