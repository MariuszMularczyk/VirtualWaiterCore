using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualWaiterCore.Dictionaries;

namespace VirtualWaiterCore.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ProductListDTO> GetAll(ProductType producType); 
        List<ProductListDTO> GetAllToMenu(ProductType producType); 
    }
}
