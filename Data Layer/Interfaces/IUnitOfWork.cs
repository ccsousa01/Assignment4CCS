


namespace DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; set; }
        IOrderDetailsRepository  OrderDetails { get; set; }
        IProductRepository Products { get; set; }
        ICategoryRepository Categories { get; set; }
        
        /// <summary> Save all current changes for the Repositories  </summary>
        int Complete();
    }
}
