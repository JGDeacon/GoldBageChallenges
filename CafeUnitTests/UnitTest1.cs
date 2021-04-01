using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static MenuRepo _menuRepo = new MenuRepo();
        //private static IngredientRepo _ingredientRepo = new IngredientRepo();

        [TestMethod]
        public void AddMenuItemTest()
        {
            //Act
            bool result = _menuRepo.AddMeal("Test", "Yummy", 5.99m, GetIngredients());
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetAllMenuItemsTrue()
        {

            Assert.AreEqual(1, _menuRepo.GetAllMenuItems().Count);
        }
       
        [TestMethod]
        public void GetMenuItemTrue()
        {
            //Menu item = PrepMenuItem();
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient sugar = new Ingredient("Sugar");
            Ingredient fries = new Ingredient("Fries");
            ingredients.Add(fries);
            ingredients.Add(sugar);

            _menuRepo.AddMeal("Test", "Yummy", 5.99m, ingredients);
            Menu control = _menuRepo.GetMenuItem(1);

            Assert.AreEqual("Test",control.MealName);
        }
        [TestMethod]
        public void UpdateMenuItemTrue()
        {
            //Act
            PrepMenuItem();
            Menu newItem = new Menu(2, "Update", "Updated", 9.99m, GetIngredients());
            Console.WriteLine(_menuRepo.GetMenuItem(1).Description);
            _menuRepo.UpdateMenuItem(newItem, 1);
            //Assert
            Assert.AreEqual(newItem.Description, _menuRepo.GetMenuItem(1).Description);
        }
        [TestMethod]
        public void zDeleteMenuItemTrue()
        {
            PrepMenuItem();
            Assert.IsTrue(_menuRepo.DeleteMenuItem(1));
        }
        private Menu PrepMenuItem()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient sugar = new Ingredient("Sugar");
            Ingredient fries = new Ingredient("Fries");
            ingredients.Add(fries);
            ingredients.Add(sugar); 

            _menuRepo.AddMeal("Test", "Yummy", 5.99m, ingredients);
            Menu testMenu = _menuRepo.GetMenuItem(1);
            return testMenu;
        }
        private List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient sugar = new Ingredient("Sugar");
            Ingredient fries = new Ingredient("Fries");
            ingredients.Add(fries);
            ingredients.Add(sugar);

            return ingredients;
        }
    }
}
