
using DataTransferObjects.DataServiceDTOs;
using ServiceLayer.ViewModels;
using System.Collections.Generic;

namespace ServiceLayer
{
    internal static class ProductMapper
    {

        internal static ProductCompleteViewModel MapProductReqSixDTOToProductViewModel(ProductReqSixDTO dto, string url = "")
        {
            return new ProductCompleteViewModel
            {
                Url = url,
                Name = dto.ProductName,
                Id = dto.ProductId,
                UnitPrice = dto.UnitPrice,
                QuantityPerUnit = dto.QuantityPerUnit,
                Category = new CategoryViewModel { Id = dto.CategoryId, Name = dto.CategoryName, Description = dto.CategoryDescription, Url = ""}
            };
        }


        internal static IEnumerable<ProductCategoryViewModel> MapProductReqSevenDTOsToProductCategoryViewModels(IEnumerable<ProductReqSevenDTO> dtos, string url = "")
        {
            List<ProductCategoryViewModel> vms = new List<ProductCategoryViewModel>();
            foreach (var d in dtos)
            {
                if (string.IsNullOrEmpty(d.CategoryName) || string.IsNullOrEmpty(d.ProductName))
                    return null;
                vms.Add(new ProductCategoryViewModel
                {
                    Url = url,
                    ProductName = d.ProductName,
                    CategoryName = d.CategoryName
                });
            }
            if (vms.Count == 0)
                return null;
            return vms;
        }



        internal static IEnumerable<ProductCompleteViewModel> MapProductReqSixDTOsToProductCompleteViewModels(IEnumerable<ProductReqSixDTO> dtos, string url = "")
        {
            List<ProductCompleteViewModel> vms = new List<ProductCompleteViewModel>();
            foreach (var d in dtos)
            {
                if (string.IsNullOrEmpty(d.CategoryName) || string.IsNullOrEmpty(d.ProductName))
                    return null;
                vms.Add(new ProductCompleteViewModel
                {
                    Url = url,
                    Name = d.ProductName,
                    Id = d.ProductId,
                    UnitPrice = d.UnitPrice,
                    QuantityPerUnit = d.QuantityPerUnit,
                    Category = new CategoryViewModel { Id = d.CategoryId, Name = d.CategoryName, Description = d.CategoryDescription, Url = "" }
                });
            }
            return vms;
        }



        internal static IEnumerable<ProductViewModel> MapProductReqSixDTOsToProductViewModels(IEnumerable<ProductReqSixDTO> dtos, string url = "")
        {
            List<ProductViewModel> vms = new List<ProductViewModel>();
            foreach (var d in dtos)
            {
                if (d.ProductId <= 0 || d.CategoryId <= 0)
                    return null;
                vms.Add(new ProductViewModel
                {
                    Url = url,
                    Name = d.ProductName,                    
                    UnitPrice = d.UnitPrice,                   
                   CategoryName = d.CategoryName
                });
            }
            if (vms.Count == 0)
                return null;
            return vms;
        }


    }
}
