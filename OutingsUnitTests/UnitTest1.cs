using Outings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OutingsUnitTests
{
    [TestClass]
    public class EventRepoUnitTests
    {
        [TestMethod]
        public void AddEventTrue()
        {
            EventRepo eventRepo = new EventRepo();
            DateTime dateTime = DateTime.Parse("10/31/2020");
            Assert.IsTrue(eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 12250.50m));
        }
        [TestMethod]
        public void GetEventsTrue()
        {
            EventRepo eventRepo = new EventRepo();
            int initialCount = eventRepo.GetEvents().Count;
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 12250.50m);
            Assert.IsTrue(initialCount + 1 == eventRepo.GetEvents().Count);
        }
        [TestMethod]
        public void ClearEventsTrue()
        {
            EventRepo eventRepo = new EventRepo();
            int initialCount = eventRepo.GetEvents().Count;
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 12250.50m);
            Assert.IsTrue(eventRepo.ClearEvents());
        }
    }
    [TestClass]
    public class ReportUnitTests
    {
        EventRepo eventRepo = new EventRepo();
        DateTime dateTime = DateTime.Parse("10/31/2020");
        private bool SeedUser()
        {
            EventRepo eventRepo = new EventRepo();
            //eventRepo.
            DateTime dateTime = DateTime.Parse("10/31/2020");
            return eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 1000.00m);
        }
        
        [TestMethod]
        public void ReportDateRangeTrue()
        {
            
            Reports reports = new Reports();
            
            Assert.IsTrue(SeedUser());
        }
        [TestMethod]
        public void ReportAttendeeRangeTrue()
        {

            eventRepo.ClearEvents();
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 1000.00m);
            Reports reports = new Reports();
            
            Assert.IsTrue(reports.GetMatchingEvents(eventRepo.GetEvents(), 50, 50).Count == 1);
        }
        [TestMethod]
        public void ReportTotalCostRangeTrue()
        {
            eventRepo.ClearEvents();
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 1000.00m);
            Reports reports = new Reports();

            Assert.IsTrue(reports.GetMatchingEvents(eventRepo.GetEvents(), 1000m, 1000m, "Total Cost").Count == 1);
        }
        [TestMethod]
        public void ReportTotalCostPPRangeTrue()
        {
            eventRepo.ClearEvents();
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 1000.00m);
            Reports reports = new Reports();

            Assert.IsTrue(reports.GetMatchingEvents(eventRepo.GetEvents(), 20.00m, 20.0m, "Per Person Cost").Count == 1);
        }
        [TestMethod]
        public void ReportTotalEventTypeTrue()
        {
            eventRepo.ClearEvents();
            DateTime dateTime = DateTime.Parse("10/31/2020");
            eventRepo.AddEvent(Events.AmusementPark, 50, dateTime, 12250.50m);
            Reports reports = new Reports();

            Assert.IsTrue(reports.GetMatchingEvents(eventRepo.GetEvents(), Events.AmusementPark).Count == 1);
        }

    }
}
