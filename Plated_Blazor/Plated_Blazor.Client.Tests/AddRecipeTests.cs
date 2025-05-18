using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Plated_Blazor.Client.Components.Pages;
using Plated_Blazor.Client.Models;
using Plated_Blazor.Client.Services;
using Plated_Blazor.Client.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plated_Blazor.Client.Components.Pages.Tests
{
    [TestClass()]
    public class AddRecipeTests
    {
        [TestMethod()]
        public void RedirectToHome_Test()
        {
            // Arrange
            var addRecipe = new AddRecipe();
            var fakeNavigationManager = new FakeNavigationManager();
            addRecipe.NavigationManager = fakeNavigationManager;

            // Act
            addRecipe.RedirectToHome();

            // Assert
            Assert.AreEqual("/", fakeNavigationManager.NavigatedTo);
        }

        [TestMethod()]
        public async Task AddRecipePage_ApiCallTest()
        {
            // Arrange  
            var addRecipe = new AddRecipe();
            var newRecipe = NewRecipe();
            var fakeNavigationManager = new FakeNavigationManager();
            var mockApiService = new Mock<IApiService>();
            mockApiService.Setup(x => x.PostRecipe(It.IsAny<Recipe>()))
                .Returns(Task.CompletedTask);

            addRecipe.newRecipe = newRecipe;
            addRecipe.NavigationManager = fakeNavigationManager;
            addRecipe.ApiService = mockApiService.Object;

            // Act  
            await addRecipe.AddRecipePage();

            // Assert  
            Assert.IsTrue(string.IsNullOrEmpty(addRecipe.error),"Error text exists");
            mockApiService.Verify(x => x.PostRecipe(It.IsAny<Recipe>()), Times.Once, "PostRecipe was not called exactly once.");
        }

        [TestMethod()]
        public async Task AddRecipePage_RedirectTest()
        {
            // Arrange
            var addRecipe = new AddRecipe();
            var newRecipe = NewRecipe();
            var fakeNavigationManager = new FakeNavigationManager();
            var mockApiService = new Mock<IApiService>();
            mockApiService.Setup(x => x.PostRecipe(It.IsAny<Recipe>()))
                .Returns(Task.CompletedTask);

            addRecipe.newRecipe = newRecipe;
            addRecipe.NavigationManager = fakeNavigationManager;
            addRecipe.ApiService = mockApiService.Object;

            // Act
            await addRecipe.AddRecipePage();

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(addRecipe.error),"Error text exists");
            Assert.AreEqual("/", fakeNavigationManager.NavigatedTo);
        }

        private Recipe NewRecipe()
        {
            return new Recipe
            {
                Id = 0,
                Title = "Test Recipe",
                Category = "Pasta",
                Material = "Test Material$Test Material2"
            };
        }
    }
}