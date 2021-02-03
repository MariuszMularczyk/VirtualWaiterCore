using VirtualWaiterCore.Application.Abstraction;
using VirtualWaiterCore.Domain;
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
    public interface IOrderService : IService
    {
        List<List<ProductItemDataDTO>> Add(OrderAddVM model);
        List<List<ProductItemDataDTO>> GetOrders();
        List<OrderListDTO> GetDrinks();
        List<List<ProductItemDataDTO>> SetStatus(int orderId);
        void SetCoocks(int orderId);
        void SetStatus(int orderId, int productType);
    }
}