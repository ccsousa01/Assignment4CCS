

namespace DataTransferObjects.DataServiceDTOs
{
    /// <summary> The data transfer object containing the required data (CategoryId, CategoryName, CategoryDescription) stated in data-service requirement 9 "Get Category by ID" </summary>
    public class CategoryReqNineDTO
    {
        public int CategoryId { get; set; }      
        public string CategoryName { get; set; }      
        public string CategoryDescription { get; set; } 
    }

}
