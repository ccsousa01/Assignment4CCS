
using DataLayer.Interfaces;
using DataLayer.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataTransferObjects.DataServiceDTOs;


namespace DataLayer.Repositories
{
    internal class ProductRepository: IProductRepository
    {

        private readonly NorthWindContext _context;


        internal ProductRepository(NorthWindContext context)
        {
            _context = context;
        }


        #region   Region  - Assignment 4.1 related (using domain model objects)
        
        /// <summary> Get a specific Product & its' associated Category </summary>
        /// <param name="productID"> The id associated with a specific product </param>
        public Product GetProduct(int productID)  
        {
            try
            {
                return _context.Product.Where(q=>q.Id == productID).Include(q=>q.Category).First();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


        /// <summary> Get all Products & their associated Category, which include the input keyword within the Product's Name field. </summary>
        /// <param name="productName"> The input keyword to use in the Product name search </param>
        public IEnumerable<Product> GetProductsByKeywordSearch(string productName)  
        {
            try
            {
                return _context.Product.Where(q => q.Name.Contains(productName)).Include(q => q.Category).ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


        /// <summary> Get all products associated with a specific category </summary>
        /// <param name="categoryID"> the id of a specific category </param>
        public IEnumerable<Product> GetProductsByCategory(int categoryID)    
        {
            try
            {
                return _context.Product.Where(q=>q.CategoryID == categoryID).Include(q=>q.Category).ToList();
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }
        
        #endregion


        /// <summary> Get a specific Product & its' associated Category </summary>
        /// <param name="productID"> The id associated with a specific product </param>
        public ProductReqSixDTO GetProductAsDTO(int productID)
        {
            try
            {
                Product p = _context.Product.Where(q => q.Id == productID).Include(q => q.Category).First();
                return ProductMapper.MapProductToProductReqSixDTO(p);
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all Products & their associated Category, which include the input keyword within the Product's Name field. </summary>
        /// <param name="productName"> The input keyword to use in the Product name search </param>
        public IEnumerable<ProductReqSevenDTO> GetProductsAsDTOsByKeywordSearch(string productName)
        {
            try
            {
                var pList = _context.Product.Where(q => q.Name.Contains(productName)).Include(q => q.Category);
                return ProductMapper.MapProductsToProductReqSevenDTOs(pList);

            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }



        /// <summary> Get all products associated with a specific category </summary>
        /// <param name="categoryID"> the id of a specific category </param>
        public IEnumerable<ProductReqSixDTO> GetProductsAsDTOsByCategory(int categoryID)
        {
            try
            {
                var pList = _context.Product.Where(q => q.CategoryID == categoryID).Include(q => q.Category).ToList();
                return ProductMapper.MapProductsToProductReqSixDTO(pList);
            }
            catch (Exception ex)
            {
                UnitOfWork.WriteErrorLog(ex);
            }
            return null;
        }


    }
}
