
using DataLayer.Model;
using System.Collections.Generic;
using DataTransferObjects.DataServiceDTOs;


namespace DataLayer.Interfaces
{
    public interface ICategoryRepository
    {
        CategoryReqNineDTO GetCategoryAsDTO(int categoryID);
        IEnumerable<CategoryReqNineDTO> GetCategoriesAsDTOs();
        CategoryReqNineDTO Create(string name, string description);
        bool Update(int id, string name, string description);
        bool Delete(int id);

        /*****   CCS: assignment 4.1   *****/
        // Category GetCategory(int categoryID);
        // IEnumerable<Category> GetCategories();
        // Category CreateCategory(string name, string description);
    }
}
