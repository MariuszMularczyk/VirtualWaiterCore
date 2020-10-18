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
    public class AppetizerService : ServiceBase, IAppetizerService
    {

        public IAppetizerRepository _appetizerRepository { get; set; }
        public AppetizerService(IAppetizerRepository appetizerRepository)
        {
            _appetizerRepository = appetizerRepository;
        }

        public void Add(AppetizerAddVM model)
        {
            Appetizer appetizer = new Appetizer()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _appetizerRepository.Add(appetizer);
            _appetizerRepository.Save();
        }
        public List<AppetizerListDTO>GetAppetizers()
        {
            return _appetizerRepository.GetAll();
        }

        public AppetizerEditVM GetAppetizer(int id) {

            Appetizer appetizer = _appetizerRepository.GetSingle(x => x.Id == id);
            AppetizerEditVM model = new AppetizerEditVM()
            {
                Id = appetizer.Id,
                Name = appetizer.Name,
                Description = appetizer.Description,
                Price = appetizer.Price,
                TimeOfPreparation = appetizer.TimeOfPreparation,
                Image = Convert.ToBase64String(appetizer.Image)
            };
            return model;
        }
        public void Edit(AppetizerEditVM model)
        {
            Appetizer appetizer = new Appetizer()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image)
            };
            _appetizerRepository.Edit(appetizer);
            _appetizerRepository.Save();
        }

    }
}
