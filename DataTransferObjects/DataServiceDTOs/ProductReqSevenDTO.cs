

namespace DataTransferObjects.DataServiceDTOs
{
    /// <summary> The data transfer object containing the required data (ProductName, CategoryName)  stated in data-service requirement 7 "Get a a list of products that contains a substring" </summary>
    public class ProductReqSevenDTO
    {
        public string ProductName { get; set; } 
        public string CategoryName { get; set; }
    }

}
