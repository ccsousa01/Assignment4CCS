
using DataLayer.Model;
using DataTransferObjects.DataServiceDTOs;
using System.Collections.Generic;


namespace DataLayer
{
    internal static class ProductMapper
    {

        /// <summary> Map attributes from a Product & its associated Category to a ProductReqSixDTO data transfer object </summary>
        /// <param name="p"> the specific Product domain model object </param>
        internal static ProductReqSixDTO MapProductToProductReqSixDTO(Product p)
        {
            if (p == null || string.IsNullOrEmpty(p.Name))
                return null;
            return new ProductReqSixDTO
            {
                ProductId = p.Id,
                ProductName = p.Name,
                UnitPrice = p.UnitPrice,
                QuantityPerUnit = p.QuantityPerUnit,
                CategoryId = p.Category.Id,
                CategoryName = p.Category.Name,
                CategoryDescription = p.Category.Description
            };
        }


        /// <summary> Map attributes from a list of Products & its associated Category to a list of ProductReqSixDTO data transfer objects </summary>
        /// <param name="p"> the specific Product domain model object </param>
        internal static IEnumerable<ProductReqSixDTO> MapProductsToProductReqSixDTO(IEnumerable<Product> pList)
        {
            if (pList == null)
                return null;
            List<ProductReqSixDTO> dtos = new List<ProductReqSixDTO>();
            foreach (var p in pList)
            {
                if (string.IsNullOrEmpty(p.Name) || string.IsNullOrEmpty(p.Category.Name))
                    return null;
                dtos.Add(new ProductReqSixDTO
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    UnitPrice = p.UnitPrice,
                    QuantityPerUnit = p.QuantityPerUnit,
                    CategoryId = p.Category.Id,
                    CategoryName = p.Category.Name,
                    CategoryDescription = p.Category.Description
                });
            }
            return dtos;
        }


        /// <summary> Map attributes from a Product & its associated Category to a ProductReqSevenDTO data transfer object </summary>
        /// <param name="p"> the specific Product domain model object </param>
        internal static ProductReqSevenDTO MapProductToProductReqSevenDTO(Product p)
        {
            if (string.IsNullOrEmpty(p.Name) || string.IsNullOrEmpty(p.Category.Name))
                return null;
            return new ProductReqSevenDTO
            {
                ProductName = p.Name,               
                CategoryName = p.Category.Name
            };
        }


        /// <summary> Map attributes from a list of Products & its associated Category to a list of ProductReqSevenDTO data transfer objects </summary>
        /// <param name="p"> the specific Product domain model object </param>
        internal static IEnumerable<ProductReqSevenDTO> MapProductsToProductReqSevenDTOs(IEnumerable<Product> pList)
        {
            if (pList == null)
                return null;
            List<ProductReqSevenDTO> dtos = new List<ProductReqSevenDTO>();
            foreach (var p in pList)
            {
                if (string.IsNullOrEmpty(p.Name) || string.IsNullOrEmpty(p.Category.Name))
                    return null;
                dtos.Add(new ProductReqSevenDTO
                {
                    ProductName = p.Name,
                    CategoryName = p.Category.Name
                });
            }
            return dtos;
        }


    }

}
