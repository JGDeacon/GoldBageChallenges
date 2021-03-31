using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BadgesUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBadgeTrue()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            Assert.IsTrue(badgeRepo.AddBadge("Hallway"));
        }
        [TestMethod]
        public void EditBadgeTrue()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("Hallway");
            Assert.IsTrue(badgeRepo.EditBadge(1, "Main"));

        }
        [TestMethod]
        public void ListAllBadgesTrue()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("Hallway");
            badgeRepo.AddBadge("Hallway");
            badgeRepo.AddBadge("Hallway");

            Assert.AreEqual(3, badgeRepo.ListAllBadges().Count);

        }
        [TestMethod]
        public void ListMatchingDoorTrue()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("Hallway");
            badgeRepo.AddBadge("Hallway");
            badgeRepo.AddBadge("Main");
            badgeRepo.AddBadge("Hallway");

            Assert.AreEqual(1, badgeRepo.ListMatchingDoor("Main").Count);

        }
        [TestMethod]
        public void ClearBadgeTrue()
        {
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("Hallway");
            Assert.IsTrue(badgeRepo.ClearBadge(1));

        }
    }
}
