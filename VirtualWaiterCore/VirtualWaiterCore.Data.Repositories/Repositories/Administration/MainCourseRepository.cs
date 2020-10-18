using VirtualWaiterCore.Domain;
using VirtualWaiterCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public class MainCourseRepository : Repository<MainCourse, MainDatabaseContext>, IMainCourseRepository
    {
        public MainCourseRepository(MainDatabaseContext context) : base(context)
        { }

        public List<MainCourseListDTO> GetAll()
        {
            return Context.MainCourses.Select(x => new MainCourseListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                TimeOfPreparation = x.TimeOfPreparation,
                Image = Convert.ToBase64String(x.Image)
            }).ToList();
        }

    }
}
