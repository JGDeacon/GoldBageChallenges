using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient> MealIngredients { get; set; } = new List<Ingredient>();

        public Menu()
        {
            MealIngredients = new List<Ingredient>();
        }
        public Menu(int mealNumber, string mealName, string description, decimal price, List<Ingredient> mealIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            MealIngredients = mealIngredients;
        }

    }
}
