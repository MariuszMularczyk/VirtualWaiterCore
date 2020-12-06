using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VirtualWaiterCore.Data;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Application
{
    public interface IProductService : IService
    {
        void Add(ProductAddVM model, ProductType productType);
        List<ProductListDTO> GetProducts(ProductType produtType);
        List<ProductListDTO> GetProductsToMenu(ProductType produtType);
        ProductEditVM GetProduct(int id);
        void Edit(ProductEditVM model);
        void Delete(int id);
    }
}