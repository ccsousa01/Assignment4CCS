
using DataLayer.Interfaces;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly NorthWindContext _context;


        internal OrderRepository(NorthWindContext context) 
        {
            _context = context;
        }


        /// <summary> Get a specific order from the database </summary>
        /// <param name="orderID"> the id associated with a specific order </param>
        public Order GetOrder(int orderID)
        {
            try
            {
                return _context.Order.Where(q => q.Id == orderID).Include(q=>q.Details).ThenInclude(d=>d.Product).ThenInclude(p=>p.Category).First();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all orders from the database </summary>
        public IEnumerable<Order> GetOrders()
        {
            try
            {
                return _context.Order.ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all orders associated with a specific shipping name </summary>
        /// <param name="shippingName"> the name of a given shipping field </param>
        public IEnumerable<Order> GetOrdersByShippingName(string shippingName)
        {
            try
            {
                return _context.Order.Where(q => q.ShipName == shippingName).ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


    }
}
