using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public Ingredient()
        {

        }
        public Ingredient(string ingredientName)
        {
            IngredientName = ingredientName;
        }
        public Ingredient(int id, string ingredientName)
        {
            IngredientID = id;
            IngredientName = ingredientName;
        }
    }
}
