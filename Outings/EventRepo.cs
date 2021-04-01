using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class EventRepo
    {
        protected readonly List<Event> _events = new List<Event>();

        public bool AddEvent(Events eventType, int attendence, DateTime eventDate, decimal eventCost)
        {
            int checkValue = _events.Count;
            Event newEvent = new Event(eventType, attendence, eventDate, eventCost);
            _events.Add(newEvent);
            return (checkValue + 1 == _events.Count) ? true : false;
        }
        public List<Event> GetEvents()
        {
            return _events;
        }
        public bool ClearEvents()
        {
            _events.RemoveRange(0, _events.Count);
            return (_events.Count == 0) ? true : false;
        }
    }
}
