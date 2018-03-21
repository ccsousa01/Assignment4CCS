
using DataLayer.Model;
using System.Collections.Generic;
using DataTransferObjects.DataServiceDTOs;


namespace DataLayer.Interfaces
{
    public interface IProductRepository
    {
        ProductReqSixDTO GetProductAsDTO(int productID);
        IEnumerable<ProductReqSevenDTO> GetProductsAsDTOsByKeywordSearch(string productName);
        IEnumerable<ProductReqSixDTO> GetProductsAsDTOsByCategory(int categoryID);

        /*****   CCS: assignment 4.1   *****/
        // Product GetProduct(int productID);      
        // IEnumerable<Product> GetProductsByKeywordSearch(string productName);  
        // IEnumerable<Product> GetProductsByCategory(int categoryID);        
    }
}
