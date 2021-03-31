using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbecue
{
    public class Orders
    {
        public int ID { get; set; }
        public String Party { get; set; }
        public Menu MenuID { get; set; }

        public Orders()
        {

        }
        public Orders(int id, string party, Menu menuID)
        {
            ID = id;
            Party = party;
            MenuID = menuID;
        }
    }

}
