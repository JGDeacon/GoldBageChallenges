using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbecue
{
    public class PartyRepo
    {
        protected readonly List<Party> _parties = new List<Party>();

        public bool AddParty(string name, List<Menu> menu)
        {
            int id = _parties.Count+1;
            Party party = new Party(id, name, menu);
            _parties.Add(party);
            return (id == _parties.Count) ? true : false;
        }
        public List<Party> GetParties()
        {
            return _parties;
        }
        public bool ClearParties()
        {
            _parties.RemoveRange(0, _parties.Count);
            return (0 == _parties.Count);
        }
    }
}
