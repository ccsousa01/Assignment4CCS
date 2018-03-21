
using DataLayer.Model;
using System.Collections.Generic;


namespace DataLayer.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        IEnumerable<OrderDetails> GetOrderDetailsByProductId(int productId);
    }
}
