
using DataTransferObjects.DataServiceDTOs;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    internal static class CategoryMapper
    {

        internal static CategoryViewModel MapCategoryReqNineDTOToCategoryViewModel(CategoryReqNineDTO dto, string url = "")
        {
            if (dto == null || dto.CategoryId <= 0 || string.IsNullOrEmpty(dto.CategoryName))
                return null;
            return new CategoryViewModel
            {
                Url = url,
                Id = dto.CategoryId,
                Name = dto.CategoryName,
                Description = dto.CategoryDescription                
            };
        }


        internal static IEnumerable<CategoryViewModel> MapCategoryReqNineDTOsToCategoryViewModels(IEnumerable<CategoryReqNineDTO> dtos, string url = "")
        {
            List<CategoryViewModel> vms = new List<CategoryViewModel>();
            foreach (var d in dtos)
            {
                if (d.CategoryId <= 0)
                    return null;
                vms.Add(new CategoryViewModel
                {
                    Url = url + d.CategoryId,
                    Name = d.CategoryName,
                    Description = d.CategoryDescription
                });
            }
            return vms;
        }

    }
}
