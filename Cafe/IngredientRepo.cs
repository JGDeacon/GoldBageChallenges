using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class IngredientRepo
    {
        protected readonly List<Ingredient> _ingredientList = new List<Ingredient>();
        
        //Create
        //public bool AddIngredient(string name)
        //{
        //    int[] maxID = new int[_ingredientList.Count];
        //    int count = 0;
        //    int id;

        //    if (_ingredientList.Count > 0)
        //    {
        //        foreach (Ingredient x in _ingredientList)
        //        {
        //            maxID.SetValue(x.IngredientID, count);
        //            count++;
        //        }
        //        id = maxID.Max() + 1;
        //    }
        //    else
        //    {
        //        id = 1;
        //    }
        //    Ingredient ingredient = new Ingredient(id, name);
        //    _ingredientList.Add(ingredient);
        //    bool result = (maxID.Count() < _ingredientList.Count) ? true : false;
        //    return result;

        ////}
        ////Read
        //public List<Ingredient> GetAllIngredients()
        //{
        //    return _ingredientList;
        //}
        ////Update
        ////Delete
        //public void ClearIngredients()
        //{
        //    _ingredientList.RemoveRange(0, _ingredientList.Count);
        //}






    }
}
