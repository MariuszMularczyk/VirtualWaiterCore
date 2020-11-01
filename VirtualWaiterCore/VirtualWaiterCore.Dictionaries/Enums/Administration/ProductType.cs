using System.ComponentModel.DataAnnotations;
using VirtualWaiterCore.Resources.Order;

namespace VirtualWaiterCore.Dictionaries
{
    public enum ProductType : int
    {
        Appetizer = 1,
        Dessert = 2,
        Drink = 3,
        MainCourse = 4
    }
}
