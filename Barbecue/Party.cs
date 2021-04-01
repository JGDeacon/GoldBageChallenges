using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbecue
{
    public class Party
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get { return MenuCost(); } }
        public List<Menu> MenuID { get; set; }

        public Party()
        {

        }
        public Party(int id, string name, List<Menu> menuID)
        {
            ID = id;
            Name = name;
            MenuID = menuID;
        }
        private decimal MenuCost()
        {
            decimal runningTotal = 0m;
            foreach (Menu item in MenuID)
            {
                runningTotal = runningTotal + item.Price;
            }
            return runningTotal;
        }
    }

}
