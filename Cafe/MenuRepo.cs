using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menuItems = new List<Menu>();
        //Create
        public bool AddMeal(string mealName, string description, decimal price, List<Ingredient> ingredients)
        {
            int[] maxID = new int[_menuItems.Count];
            int count = 0;
            int id=0;

            if (_menuItems.Count > 0)
            {
                foreach (Menu x in _menuItems)
                {
                    maxID.SetValue(x.MealNumber, count);
                    count++;
                }
                id = maxID.Max() + 1;
            }
            else
            {
                id = 1;
            }

            Menu meal = new Menu(id, mealName, description, price, ingredients);
            _menuItems.Add(meal);

            return (_menuItems.Count > maxID.Count()) ? true : false;
        }
        //Read
        public Menu GetMenuItem(int x)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.MealNumber == x)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuItems;
        }
        //Update
        public Menu UpdateMenuItem(Menu menu, int x)
        {
            Menu updateMenu = GetMenuItem(x);
            updateMenu.MealName = menu.MealName;
            updateMenu.Description = menu.Description;
            updateMenu.Price = menu.Price;
            updateMenu.MealIngredients = menu.MealIngredients;

            return updateMenu;
        }
        //Delete
        public bool DeleteMenuItem(int x)
        {
            int mealCount = _menuItems.Count; // For Unit Test
            Menu menu = GetMenuItem(x);
            if (menu != null)
            {
                _menuItems.Remove(menu);
            }
            

            return (mealCount > _menuItems.Count) ? true : false;
        }


    }
}
