using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plated_Blazor.Client.Components.Pages;
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
        public void AddRecipePage_Test()
        {
            // Arrange
            var addRecipe = new AddRecipe();
            var fakeNavigationManager = new FakeNavigationManager();
            addRecipe.NavigationManager = fakeNavigationManager;
            // Act
            addRecipe.AddRecipePage();
            // Assert
            Assert.AreEqual("/", fakeNavigationManager.NavigatedTo);
        }
    }
}