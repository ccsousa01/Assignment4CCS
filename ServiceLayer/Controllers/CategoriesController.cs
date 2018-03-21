
using System.Collections.Generic;
using DataLayer.Interfaces;
using DataTransferObjects.DataServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            bool result = _unitOfWork.Categories.Delete(id);
            if (!result)
                return NotFound();
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] CategoryUpdateViewModel vm)
        {
            if (vm == null)
                return NotFound();
            bool result = _unitOfWork.Categories.Update(vm.Id, vm.Name, vm.Description);
            if(!result)
                return NotFound();
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            CategoryReqNineDTO c = _unitOfWork.Categories.GetCategoryAsDTO(id);
            if (c == null || c.CategoryId <= 0)
                return NotFound();
            CategoryViewModel vm = CategoryMapper.MapCategoryReqNineDTOToCategoryViewModel(c, Url.Link(nameof(GetCategory), new { id }));
            if (vm == null)
                return NotFound();
            return Ok(vm);
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            IEnumerable<CategoryReqNineDTO> dtos = _unitOfWork.Categories.GetCategoriesAsDTOs();
            if (dtos == null)
                return null;
            IEnumerable<CategoryViewModel> vms = CategoryMapper.MapCategoryReqNineDTOsToCategoryViewModels(dtos, Url.Link(nameof(GetCategory), ""));
            if (vms == null)
                return null;
            return Ok(vms);
        }
        

        [HttpPost(Name = nameof(CreateCategory))]
        public IActionResult CreateCategory([FromBody] CategoryCreateViewModel vmodel)
        {
            if (vmodel == null)
                return null;
            CategoryReqNineDTO c = _unitOfWork.Categories.Create(vmodel.Name, vmodel.Description);
            if (c == null || c.CategoryId <= 0)
                return null;
            _unitOfWork.Complete();
            CategoryViewModel vm = CategoryMapper.MapCategoryReqNineDTOToCategoryViewModel(c, Url.Link(nameof(GetCategory), new { c.CategoryId }));
            if (vm == null)
                return null;  /////
            
            return Created(Url.RouteUrl(nameof(CreateCategory)) + "/" + c.CategoryId, vm);   // StatusCode(201);   //Ok(vm);
        }

    }
}