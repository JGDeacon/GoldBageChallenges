using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public enum Events {  AmusementPark, Bowling, Concert,Golf }
    public class Event
    {
        public Events EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPP { get { return GetPPCost(); } }
        public decimal EventCost { get; set; }


        private decimal GetPPCost()
        {
            return EventCost / Attendance;
        }

        public Event()
        {

        }
        public Event(Event newEvent)
        {
            EventType = newEvent.EventType;
            Attendance = newEvent.Attendance;
            EventDate = newEvent.EventDate;
            EventCost = newEvent.EventCost;
        }
        public Event(Events eventType, int attendance, DateTime eventDate, decimal eventCost)
        {
            EventType = eventType;
            Attendance = attendance;
            EventDate = eventDate;
            EventCost = eventCost;
        }

    }
}
