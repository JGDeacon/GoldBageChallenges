using Barbecue;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BarbecueUnitTests
{
    [TestClass]
    public class BarbecueTests
    {
        PartyRepo partyRepo = new PartyRepo();
        [TestMethod]
        public void AddPartyTrue()
        {
            List<Menu> menu = new List<Menu>();
            Assert.IsTrue(partyRepo.AddParty("Test",menu));
            partyRepo.ClearParties();
        }
        [TestMethod]
        public void ListPartyTrue()
        {
            List<Menu> menu = new List<Menu>();
            partyRepo.AddParty("Test", menu);
            Assert.IsTrue(partyRepo.GetParties().Count == 1);
            partyRepo.ClearParties();
        }
        [TestMethod]
        public void ClearPartiesTrue()
        {
            List<Menu> menu = new List<Menu>();
            partyRepo.AddParty("Test", menu);
            Assert.IsTrue(partyRepo.ClearParties());
        }

    }
}
