

namespace DataTransferObjects.DataServiceDTOs
{
    /// <summary> The data transfer object containing the required data (ProductName, UnitPrice, CategoryName) stated in data-service requirement 6 "Get a single product by ID" </summary>
    public class ProductReqSixDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

}
