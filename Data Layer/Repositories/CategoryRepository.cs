
using DataLayer.Interfaces;
using DataLayer.Model;
using DataTransferObjects.DataServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly NorthWindContext _context;   


        internal CategoryRepository(NorthWindContext context)   //ToDo: dependency injection
        {
            _context = context;
        }


        #region   Region  - Assignment 4.1 related (using domain model objects)

        /// <summary> Create a new category inside the database </summary>
        /// <param name="name"> The new category name </param>
        /// <param name="description"> The new category description </param>
        public Category CreateCategory(string name, string description)
        {
            try
            {
                var c = new Category() { Description = description, Name = name };
                _context.Category.Add(c);
                _context.SaveChanges();
                return c;    
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all categories from the database </summary>
        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return _context.Category.ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get a specific category from the database </summary>
        public Category GetCategory(int categoryID)
        {
            try
            {
                return _context.Category.Find(categoryID);
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }

        #endregion


        /// <summary> Delete a specific category </summary>
        /// <param name="categoryID"> the id associated with a category </param>
        public bool Delete(int categoryID)
        {
            try
            {
                Category c = _context.Category.Find(categoryID);
                if (c == null)
                    return false;
                _context.Category.Remove(c);
                return true;
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return false;
        }



        /// <summary> Update a specific category's name and description fields in the database </summary>
        /// <param name="id"> The id associated with a specific category </param>
        /// <param name="name"> The category name </param>
        /// <param name="description"> The category description text </param>
        public bool Update(int id, string name, string description)
        {
            Category c = _context.Category.Find(id);
            if (c == null)
                return false;           
            c.Name = name;
            c.Description = description;            
            return true;
        }



        /// <summary> Get a specific category from the database and return the necessary info as a data transfer object </summary>
        public CategoryReqNineDTO GetCategoryAsDTO(int categoryID)
        {
            var c = GetCategory(categoryID);
            return CategoryMapper.MapCategoryToCategoryReqNineDTO(c);
        }



        /// <summary> Get all categories from the database and return the necessary info as a list of data transfer object </summary>
        public IEnumerable<CategoryReqNineDTO> GetCategoriesAsDTOs()
        {
            try
            {
                var cList = GetCategories();
                return CategoryMapper.MapCategoriesToCategoryReqNineDTOs(cList);
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


        /// <summary> Create a new category inside the database and return the necessary info as a data transfer object </summary>
        /// <param name="name"> The new category name </param>
        /// <param name="description"> The new category description </param>
        public CategoryReqNineDTO Create(string name, string description)
        {
            try
            {
                var c = CreateCategory(name, description);
                return CategoryMapper.MapCategoryToCategoryReqNineDTO(c);   
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


    }
}
