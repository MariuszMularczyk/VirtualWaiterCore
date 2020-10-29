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
    public class DessertService : ServiceBase, IDessertService
    {

        public IDessertRepository _dessertRepository { get; set; }
        public DessertService(IDessertRepository dessertRepository)
        {
            _dessertRepository = dessertRepository;
        }

        public void Add(DessertAddVM model)
        {
            Dessert dessert = new Dessert()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _dessertRepository.Add(dessert);
            _dessertRepository.Save();
        }
        public List<DessertListDTO>GetDesserts()
        {
            return _dessertRepository.GetAll();
        }

        public DessertEditVM GetDessert(int id) {

            Dessert dessert = _dessertRepository.GetSingle(x => x.Id == id);
            DessertEditVM model = new DessertEditVM()
            {
                Id = dessert.Id,
                Name = dessert.Name,
                Description = dessert.Description,
                Price = dessert.Price,
                TimeOfPreparation = dessert.TimeOfPreparation,
                Image = Convert.ToBase64String(dessert.Image)
            };
            return model;
        }
        public void Edit(DessertEditVM model)
        {
            Dessert dessert = new Dessert()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _dessertRepository.Edit(dessert);
            _dessertRepository.Save();
        }
        public void Delete(int id)
        {
            Dessert dessert = _dessertRepository.GetSingle(x => x.Id == id);
            _dessertRepository.Delete(dessert);
            _dessertRepository.Save();
        }
    }
}
