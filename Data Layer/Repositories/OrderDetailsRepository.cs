
using DataLayer.Interfaces;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
    internal class OrderDetailsRepository : IOrderDetailsRepository
    {

        private readonly NorthWindContext _context;


        internal OrderDetailsRepository(NorthWindContext context)
        {
            _context = context;        
        }



        /// <summary> Get all order detail objects associated with a specific order </summary>
        /// <param name="orderID"> The id associated with a specific order </param>      
        public IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderID)
        {
            try
            {
                return _context.OrderDetails.Include(p=>p.Product).Where(q=>q.OrderId == orderID).ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all order detail objects associated with a specific product </summary>
        /// <param name="productId"> The id associated with a specific product </param>      
        public IEnumerable<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            try
            {
                return _context.OrderDetails.Include(o => o.Order).Include(p=>p.Product).Where(q => q.ProductId == productId).ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


    }
}
