using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VirtualWaiterCore.Data;

namespace VirtualWaiterCore.Application
{
    public interface IMainCourseService : IService
    {
        void Add(MainCourseAddVM model);
        List<MainCourseListDTO> GetMainCourses();
        MainCourseEditVM GetMainCourse(int id);
        void Edit(MainCourseEditVM model);
    }
}