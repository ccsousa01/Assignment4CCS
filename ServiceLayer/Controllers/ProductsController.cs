

using System.Collections.Generic;
using DataLayer.Interfaces;
using DataTransferObjects.DataServiceDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }


        //[HttpGet("{id}", Name = nameof(GetProduct))]
        //public IActionResult GetProduct(int id)
        //{
        //    ProductReqSixDTO p = _unitOfWork.Products.GetProductAsDTO(id);
        //    if (p == null || string.IsNullOrEmpty(p.CategoryName) || string.IsNullOrEmpty(p.ProductName))
        //        return NotFound();
        //    ProductViewModel vm = ProductMapper.MapProductReqSixDTOToProductViewModel(p, Url.Link(nameof(GetProduct), new { id }));
        //    if(vm == null)
        //        return NotFound();
        //    return Ok(vm);
        //}


        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var p = _unitOfWork.Products.GetProductAsDTO(id); 
            if (p == null || string.IsNullOrEmpty(p.CategoryName) || string.IsNullOrEmpty(p.ProductName))
                return NotFound();
            ProductCompleteViewModel vm = ProductMapper.MapProductReqSixDTOToProductViewModel(p, Url.Link(nameof(GetProduct), new { id }));
            if (vm == null)
                return NotFound();
            return Ok(vm);
        }


        
        [HttpGet("name/{name}", Name = nameof(GetProductsNameSearch))]
        public IActionResult GetProductsNameSearch(string name)
        {
            IEnumerable<ProductReqSevenDTO> p = _unitOfWork.Products.GetProductsAsDTOsByKeywordSearch(name);
            if (p == null)
                return NotFound(new List<ProductCategoryViewModel>());
            IEnumerable<ProductCategoryViewModel> vm = ProductMapper.MapProductReqSevenDTOsToProductCategoryViewModels(p, Url.Link(nameof(GetProductsNameSearch), new { name }));
            if (vm == null)
                return NotFound(new List<ProductCategoryViewModel>());
            return Ok(vm);
        }


        [HttpGet("category/{categoryId}", Name = nameof(GetProductsByCategory))]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            IEnumerable<ProductReqSixDTO> p = _unitOfWork.Products.GetProductsAsDTOsByCategory(categoryId);
            if (p == null)
                return NotFound(new List<ProductViewModel>());
            IEnumerable<ProductViewModel> vm = ProductMapper.MapProductReqSixDTOsToProductViewModels(p, Url.Link(nameof(GetProductsByCategory), new { categoryId }));
            if (vm == null)
                return NotFound(new List<ProductViewModel>());
            return Ok(vm);
        }
        

    }

}