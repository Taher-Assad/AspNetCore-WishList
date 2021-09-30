using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace WishListTests
{
    public class CreateItemControllerTests
    {
        [Fact(DisplayName = "Create ItemController @create-itemcontroller")]
        public void CreateItemControllerTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "ItemController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`ItemController.cs` was not found in the `Controllers` folder.");

            var controllerType = TestHelpers.GetUserType("WishList.Controllers.ItemController");

            Assert.True(controllerType != null, "`ItemController.cs` was found, but it appears it does not contain a `public` class `ItemController`.");
            Assert.True(controllerType.BaseType == typeof(Controller), "`ItemController` was found, but does not appear to inherit the `Controller` class from the `Microsoft.AspNetCore.Mvc` namespace.");

            var applicationDbContextType = TestHelpers.GetUserType("WishList.Data.ApplicationDbContext");

            Assert.True(applicationDbContextType != null, "class `ApplicationDbContext` was not found, this class should already exist in the `Data` folder, if you receive this you may have accidentally deleted or renamed it.");

            // Verify ItemController contains a private property _context of type ApplicationDbContext
            var contextField = controllerType.GetField("_context", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.True(contextField != null, "`ItemController` was found, but does not appear to contain a `private` `readonly` field `_context` of type `ApplicationDbConetext`.");

            // Verify ItemController contains a constructor has a parameter of type ApplicationDbContext
            var constructor = controllerType.GetConstructor(new Type[] { applicationDbContextType });
            Assert.True(constructor != null, "`ItemController` was found, but did not contain a constructor accepting a parameter of type `ApplicationDbContext`.");

            // Verify _context is set by the constructor's parameter
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            var pattern = @"public\s*ItemController\s*?[(]\s*?ApplicationDbContext\s*context\s*?[)]\s*?{\s*?_context\s*?=\s*?context\s*?;\s*?}";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`ItemController`'s constructor did not set the `_context` property to the provided `ApplicationDbContext` parameter.");
        }

        [Fact(DisplayName = "Create Item Index Action @create-item-index-action")]
        public void CreateItemIndexActionTest()
        {
       
        }

        [Fact(DisplayName = "Create Item Create HttpGet Action @create-item-create-httpget-action")]
        public void CreateItemCreateHttpGetActionTest()
        {
        }

        [Fact(DisplayName = "Create Item Create HttpPost Action @create-item-create-httppost-action")]
        public void CreateItemCreateHttpPostActionTest()
        {
       
        }

        [Fact(DisplayName = "Create Item Delete Action @create-item-delete-action")]
        public void CreateItemDeleteActionTest()
        {
        
        }
    }
}
