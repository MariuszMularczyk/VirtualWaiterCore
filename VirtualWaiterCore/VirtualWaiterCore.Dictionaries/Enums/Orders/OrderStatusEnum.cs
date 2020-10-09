using System.ComponentModel.DataAnnotations;
using VirtualWaiterCore.Resources.Order;

namespace VirtualWaiterCore.Dictionaries
{
    public enum OrderStatusEnum : int
    {
        [Display(ResourceType = typeof(OrderStatusResource), Name = "OrderStatus_Awaiting")]
        Awaiting = 1,
        [Display(ResourceType = typeof(OrderStatusResource), Name = "OrderStatus_InProgress")]
        InProgress = 2,
        [Display(ResourceType = typeof(OrderStatusResource), Name = "OrderStatus_Done")]
        Done = 3
    }
}
