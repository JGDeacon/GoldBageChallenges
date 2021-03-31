using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class Badge
    {
        public int ID { get; set; }
        public string Door { get; set; }
        public Dictionary<int, string> InvididualBadge { get; set; } = new Dictionary<int, string>();

        public Badge()
        {

        }
    }
}
