
using DataLayer.Model;
using DataTransferObjects.DataServiceDTOs;
using System.Collections.Generic;


namespace DataLayer
{
    internal static class CategoryMapper
    {

        /// <summary> Map attributes from a Category to a CategoryReqNineDTO data transfer object </summary>
        /// <param name="c"> the specific Category domain model object </param>
        internal static CategoryReqNineDTO MapCategoryToCategoryReqNineDTO(Category c)
        {
            if (c == null || c.Id <= 0)
                return null;
            return new CategoryReqNineDTO
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                CategoryDescription = c.Description
            };
        }


        /// <summary> Map attributes from a list of Categories to a list of CategoryReqNineDTO data transfer objects </summary>
        /// <param name="cList"> the specific Category domain model objects </param>
        internal static IEnumerable<CategoryReqNineDTO> MapCategoriesToCategoryReqNineDTOs(IEnumerable<Category> cList)
        {
            if (cList == null)
                return null;
            List<CategoryReqNineDTO> dtos = new List<CategoryReqNineDTO>();
            foreach (var c in cList)
            {
                if (c.Id <= 0)
                    return null;
                dtos.Add(new CategoryReqNineDTO
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    CategoryDescription = c.Description
                });

            }
            return dtos;
        }


    }

}
