using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class Reports
    {

        //Event Date Range
        public List<Event> GetMatchingEvents(List<Event> events, DateTime startRange, DateTime endRange)
        {
            List<Event> results = new List<Event>();
            foreach (Event item in events)
            {
                if (item.EventDate >= startRange && item.EventDate <= endRange)
                {
                    results.Add(item);
                }
            }
            return results;
        }
        //Attendance Range
        public List<Event> GetMatchingEvents(List<Event> events, int startRange, int endRange)
        {
            List<Event> results = new List<Event>();
            foreach (Event item in events)
            {
                if (item.Attendance >= startRange && item.Attendance <= endRange)
                {
                    results.Add(item);
                }
            }
            return results;
        }
        //Event Type
        public List<Event> GetMatchingEvents(List<Event> events, Events eventType)
        {
            List<Event> results = new List<Event>();
            foreach (Event item in events)
            {
                if (item.EventType == eventType)
                {
                    results.Add(item);
                }
            }
            return results;
        }
        //Event Total Cost or Per Person
        public List<Event> GetMatchingEvents(List<Event> events, decimal startRange, decimal endRange, string selection)
        {
            List<Event> results = new List<Event>();
            
            foreach (Event item in events)
            {
                if (selection == "Total Cost")
                {
                    if (item.EventCost >= startRange && item.EventCost <= endRange)
                    {
                        results.Add(item);
                    }
                }
                else if (selection == "Per Person Cost")
                {
                    if (item.CostPP >= startRange && item.CostPP <= endRange)
                    {
                        results.Add(item);
                    }
                }
                
            }
            return results;
        }
        public List<Event> OrderEvents(List<Event> events, int sort, bool ascending)
        {
            List<Event> results = new List<Event>();
            switch (sort)
            {
                case 1: //Event Type
                    if (ascending)
                    {
                        results = events.OrderBy(x => x.EventType).ToList();
                    }
                    else
                    {
                        results = events.OrderBy(x => x.EventType).Reverse().ToList();
                    }
                    break;
                case 2://Attendance
                    if (ascending)
                    {
                        results = events.OrderBy(x => x.Attendance).ToList();
                    }
                    else
                    {
                        results = events.OrderBy(x => x.Attendance).Reverse().ToList();
                    }
                    break;
                case 3://Total Cost
                    if (ascending)
                    {
                        results = events.OrderBy(x => x.EventCost).ToList();
                    }
                    else
                    {
                        results = events.OrderBy(x => x.EventCost).Reverse().ToList();
                    }
                    break;
                case 4://Cost Per Person
                    if (ascending)
                    {
                        results = events.OrderBy(x => x.CostPP).ToList();
                    }
                    else
                    {
                        results = events.OrderBy(x => x.CostPP).Reverse().ToList();
                    }
                    break;
                case 5://Event Date
                    if (ascending)
                    {
                        results = events.OrderBy(x => x.EventDate).ToList();
                    }
                    else
                    {
                        results = events.OrderBy(x => x.EventDate).Reverse().ToList();
                    }
                    break;
                default:
                    break;
            }
            return results;
        }


    }
}
