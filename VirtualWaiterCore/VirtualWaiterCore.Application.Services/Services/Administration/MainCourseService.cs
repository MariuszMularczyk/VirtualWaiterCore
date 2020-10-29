using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Application
{
    public class MainCourseService : ServiceBase, IMainCourseService
    {

        public IMainCourseRepository _mainCourseRepository { get; set; }
        public MainCourseService(IMainCourseRepository mainCourseRepository)
        {
            _mainCourseRepository = mainCourseRepository;
        }

        public void Add(MainCourseAddVM model)
        {
            MainCourse mainCourse = new MainCourse()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _mainCourseRepository.Add(mainCourse);
            _mainCourseRepository.Save();
        }
        public List<MainCourseListDTO>GetMainCourses()
        {
            return _mainCourseRepository.GetAll();
        }

        public MainCourseEditVM GetMainCourse(int id) {

            MainCourse mainCourse = _mainCourseRepository.GetSingle(x => x.Id == id);
            MainCourseEditVM model = new MainCourseEditVM()
            {
                Id = mainCourse.Id,
                Name = mainCourse.Name,
                Description = mainCourse.Description,
                Price = mainCourse.Price,
                TimeOfPreparation = mainCourse.TimeOfPreparation,
                Image = Convert.ToBase64String(mainCourse.Image)
            };
            return model;
        }
        public void Edit(MainCourseEditVM model)
        {
            MainCourse mainCourse = new MainCourse()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _mainCourseRepository.Edit(mainCourse);
            _mainCourseRepository.Save();
        }

        public void Delete(int id)
        {
            MainCourse mainCourse = _mainCourseRepository.GetSingle(x => x.Id == id);
            _mainCourseRepository.Delete(mainCourse);
            _mainCourseRepository.Save();
        }

    }
}
