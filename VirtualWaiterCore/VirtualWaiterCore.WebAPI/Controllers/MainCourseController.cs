using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualWaiterCore.Application;
using VirtualWaiterCore.Data;

namespace VirtualWaiterCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainCourseController : ControllerBase
    {

        private readonly IMainCourseService _mainCourseService;

        public MainCourseController(IMainCourseService MainCourseService)
        {
            _mainCourseService = MainCourseService;
        }

        [HttpPost("add")]
        public void Add(MainCourseAddVM model)
        {
            if (ModelState.IsValid)
            {
                _mainCourseService.Add(model);
            }
        }

        [HttpGet("getMainCourses")]
        public List<MainCourseListDTO> GetMainCourses()
        {
            return _mainCourseService.GetMainCourses();
        }

        [HttpGet("getMainCourse/{id}")]
        public MainCourseEditVM GetMainCourse(int id)
        {
            return _mainCourseService.GetMainCourse(id);
        }

        [HttpPost("edit")]
        public void Edit(MainCourseEditVM model)
        {
            _mainCourseService.Edit(model);
        }

        [HttpDelete("deleteMainCourse/{id}")]
        public void DeleteMainCourse(int id)
        {
            _mainCourseService.Delete(id);
        }
    }
}
