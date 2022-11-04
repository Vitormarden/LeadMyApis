using System;
using System.Threading.Tasks;
using Inventory.Controllers;
using Inventory.Models;
using Inventory.Services;
using Inventory.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Inventory.UnitTest
{
    public class CategoryUnitTests
    {
        private readonly CategoryController _categoryController;
        private readonly Mock<ICategoryService> _categoryServiceMock;  
        public CategoryUnitTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _categoryController = new CategoryController(_categoryServiceMock.Object);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        public async Task GetCategoryByID_ShouldReturnOk_WhenIdIsValid(int categoryId)
        {
            //Arrange
            Category  categoryMockResult = new Category { Id_Category = categoryId };
            _categoryServiceMock.Setup(categoryService => categoryService.Get(categoryId)).Returns(Task.FromResult(categoryMockResult));

            //Act
            var response = await _categoryController.GetById(categoryId);
            var statuscode = (response as ObjectResult).StatusCode;

            //Assert
            Assert.Equal(200, statuscode);

        }
        [Theory]
        [InlineData(-100)]
        public async Task  GetCategoryByID_ShouldeReturnBadRequest_WhenIdIsInvalid(int categoryId)
        {
            //Arrang
            Category categoryMockResult = new Category { Id_Category = categoryId };
            _categoryServiceMock.Setup(categoryService => categoryService.Get(categoryId)).Returns(Task.FromResult(categoryMockResult));
            //Act
            var response = await _categoryController.GetById(categoryId);
            var statuscode = (response as ObjectResult).StatusCode;
            //Assert
            Assert.Equal(400, statuscode);
        }
       
    }
}
