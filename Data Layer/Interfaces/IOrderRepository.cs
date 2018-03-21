
using DataLayer.Model;
using System.Collections.Generic;


namespace DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderID);
        IEnumerable<Order> GetOrdersByShippingName(string shippingName);
        IEnumerable<Order> GetOrders();
    }
}
