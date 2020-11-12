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
    public class ProductService : ServiceBase, IProductService
    {

        public IProductRepository _productRepository { get; set; }


        public virtual void Add(ProductAddVM model, ProductType productType)
        {
            Product product = new Product()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                TimeOfPreparation = model.TimeOfPreparation,
                Image = Convert.FromBase64String(model.Image),
                ProductType = productType
            };
            _productRepository.Add(product);
            _productRepository.Save();
        }
        public virtual List<ProductListDTO>GetProducts(ProductType productType)
        {
            return _productRepository.GetAll(productType);
        }

        public virtual ProductEditVM GetProduct(int id) {

            Product product = _productRepository.GetSingle(x => x.Id == id);
            ProductEditVM model = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                TimeOfPreparation = product.TimeOfPreparation,
                Image = Convert.ToBase64String(product.Image)
            };
            return model;
        }
        public virtual void Edit(ProductEditVM model)
        {
            Product product = _productRepository.GetSingle(x => x.Id == model.Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.TimeOfPreparation = model.TimeOfPreparation;
            product.Image = Convert.FromBase64String(model.Image);

            _productRepository.Edit(product);
            _productRepository.Save();
        }

        public virtual void Delete(int id)
        {
            Product product = _productRepository.GetSingle(x => x.Id == id);
            _productRepository.Delete(product);
            _productRepository.Save();
        }

    }
}
