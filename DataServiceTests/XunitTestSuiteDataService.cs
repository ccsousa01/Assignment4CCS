
using System.Linq;
using Xunit;
using DataLayer;
using DataLayer.Model;
using DataLayer.Interfaces;
using System;

namespace DataServiceTests
{
    public class XunitTestSuiteDataService
    {

        IUnitOfWork _serviceUoW = new UnitOfWork(new NorthWindContext());


        /***** Categories *****/

        [Fact]
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }


        [Fact]
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {           
            var categories = _serviceUoW.Categories.GetCategoriesAsDTOs();  //assignment 4.1 - GetCategories()
            Assert.Equal(8, categories.Count());
            Assert.Equal("Beverages", categories.First().CategoryName);    //assignment 4.1 - categories.First().Name
        }



        [Fact]
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {            
            var category = _serviceUoW.Categories.GetCategoryAsDTO(1);  //assignment 4.1 - GetCategory()
            Assert.Equal("Beverages", category.CategoryName);   //assignment 4.1 - category.Name
        }


        [Fact]
        public void CreateCategory_ValidData_CreteCategoryAndRetunsNewObject()
        {        
            var category = _serviceUoW.Categories.Create("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");
            Assert.True(category.CategoryId > 0);        //assignment 4.1 - category.Id
            Assert.Equal("Test", category.CategoryName);    //assignment 4.1 - category.Name
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndRetunsNewObject", category.CategoryDescription);   //assignment 4.1 - category.Description

            // cleanup
            _serviceUoW.Categories.Delete(category.CategoryId);     //assignment 4.1 - category.Id

            _serviceUoW.Complete();
        }


        [Fact]
        public void DeleteCategory_ValidId_RemoveTheCategory()
        {           
            var category = _serviceUoW.Categories.Create("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            var result = _serviceUoW.Categories.Delete(category.CategoryId);   //assignment 4.1 - category.Id
            _serviceUoW.Complete();
            Assert.True(result);
            category = _serviceUoW.Categories.GetCategoryAsDTO(category.CategoryId);    //assignment 4.1 - GetCategory(category.CategoryId)
            Assert.Null(category);
        }


        [Fact]
        public void DeleteCategory_InvalidId_ReturnsFalse()
        {            
            var result = _serviceUoW.Categories.Delete(-1);
            Assert.False(result);
        }



        [Fact]
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {            
            var category = _serviceUoW.Categories.Create("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");
            var result = _serviceUoW.Categories.Update(category.CategoryId, "UpdatedName", "UpdatedDescription");    //assignment 4.1 - category.Id
            Assert.True(result);
            _serviceUoW.Complete();

            category = _serviceUoW.Categories.GetCategoryAsDTO(category.CategoryId);   //assignment 4.1 - GetCategory(category.Id)

            Assert.Equal("UpdatedName", category.CategoryName);      //assignment 4.1 - category.Name
            Assert.Equal("UpdatedDescription", category.CategoryDescription);     //assignment 4.1 - category.Description

            // cleanup
            _serviceUoW.Categories.Delete(category.CategoryId);     //assignment 4.1 - category.Id 

            _serviceUoW.Complete();
        }



        [Fact]
        public void UpdateCategory_InvalidID_ReturnsFalse()
        {          
            var result = _serviceUoW.Categories.Update(-1, "UpdatedName", "UpdatedDescription");
            Assert.False(result);
        }



        /***** products *****/

        [Fact]
        public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        {
            var product = new Product();
            Assert.Equal(0, product.Id);
            Assert.Null(product.Name);
            Assert.Equal(0.0, product.UnitPrice);
            Assert.Null(product.QuantityPerUnit);
            Assert.Equal(0, product.UnitsInStock);
        }

        
        [Fact]
        public void GetProduct_ValidId_ReturnsProductWithCategory()
        {            
            var product = _serviceUoW.Products.GetProductAsDTO(1);
            Assert.Equal("Chai", product.ProductName);    //assignment 4.1 - product.Name
            Assert.Equal("Beverages", product.CategoryName);    //assignment 4.1 - product.Category.Name
        }


        [Fact]
        public void GetProduct_NameSubString_ReturnsProductsThatMachesTheSubString()
        {            
            var products = _serviceUoW.Products.GetProductsAsDTOsByKeywordSearch("ant");  //assignment 4.1 - GetProductsByKeywordSearch
            Assert.Equal(3, products.Count());
            Assert.Equal("Chef Anton's Cajun Seasoning", products.First().ProductName);    //assignment 4.1 - products.First().Name
            Assert.Equal("Guaraná Fantástica", products.Last().ProductName);      //assignment 4.1 - products.Last().Name
        }


        [Fact]
        public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        {           
            var products = _serviceUoW.Products.GetProductsAsDTOsByCategory(1);    //assignment 4.1 - GetProductsByCategory
            //Assert.Equal(12, products.Count());
            Assert.Equal("Chai", products.First().ProductName);    //assignment 4.1 - products.First().Name
            Assert.Equal("Beverages", products.First().CategoryName);     //assignment 4.1 - products.First().Category.Name
            Assert.Equal("Lakkalikööri", products.Last().ProductName);     //assignment 4.1 - products.First().Name
        }


          /***** orders *****/
        [Fact]
        public void Order_Object_HasIdDatesAndOrderDetails()
        {
            var order = new Order();
            Assert.Equal(0, order.Id);
            Assert.Equal(new DateTime(), order.Date);
            Assert.Equal(new DateTime(), order.Require);
            Assert.Null(order.Details);
            Assert.Null(order.ShipName);
            Assert.Null(order.ShipCity);
        }


        [Fact]
        public void GetOrder_ValidId_ReturnsCompleteOrder()
        {
            var order = _serviceUoW.Orders.GetOrder(10248);
            Assert.Equal(3, order.Details.Count);
            Assert.Equal("Queso Cabrales", order.Details.First().Product.Name);
            Assert.Equal("Dairy Products", order.Details.First().Product.Category.Name);
        }

    }
}
