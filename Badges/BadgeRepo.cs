using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgeRepo
    {
        protected readonly Dictionary<int, string> badgeList = new Dictionary<int, string>();

        public bool AddBadge(string doors)
        {

            Badge newBadge = new Badge();
            newBadge.ID = badgeList.Count + 1;
            newBadge.Door = doors;

            badgeList.Add(newBadge.ID, newBadge.Door);

            return (newBadge.ID == badgeList.Count) ? true : false;
        }
        public bool EditBadge(int id, string doors)
        {
            if (id <= badgeList.Count)
            {
                badgeList[id] = doors;
                if (badgeList[id] == doors)
                {
                    return true;
                }
                
            }
            return false;

        }
        public Dictionary<int, string> ListAllBadges()
        {
            return badgeList;
        }
        public List<int> ListMatchingDoor(string door)
        {
            List<int> badgeIDs = new List<int>();
            foreach (KeyValuePair<int, string> item in badgeList)
            {
                if (item.Value.Contains(door))
                {
                    badgeIDs.Add(item.Key);
                }
            }
            return badgeIDs;
        }
        public bool ClearBadge(int id)
        {
            badgeList[id] = "";
            if (badgeList[id] == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
