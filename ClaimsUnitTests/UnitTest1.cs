using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void AddClaimManualTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            Assert.IsTrue(_insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim)); 
        }
        [TestMethod]
        public void AddClaimWithClaimTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            InsClaim insClaim = new InsClaim();
            Assert.IsTrue(_insClaimRepo.AddClaim(insClaim));
        }
        [TestMethod]
        public void GetClaimTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            _insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim);
            Assert.AreEqual("Accident", _insClaimRepo.GetClaim(1).Description);
        }
        [TestMethod]
        public void GetNextClaimTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            InsClaim updateClaim = new InsClaim(1, ClaimType.Car, "Accident number 2", 2345.78m, dateOfIncident, dateOfClaim, false);
            _insClaimRepo.AddClaim(updateClaim);
            _insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim);

            Assert.AreEqual("Accident", _insClaimRepo.GetNextClaim().Description);
            
        }
        [TestMethod]
        public void GetAllClaimsTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            InsClaim updateClaim = new InsClaim(1, ClaimType.Car, "Accident number 2", 2345.78m, dateOfIncident, dateOfClaim, false);
            _insClaimRepo.AddClaim(updateClaim);
            _insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim);

            Assert.AreEqual(2, _insClaimRepo.GetAllClaims().Count);//Individual Test
           

        }
        [TestMethod]
        public void GetAllOpenClaimsTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            InsClaim updateClaim = new InsClaim(1, ClaimType.Car, "Accident number 2", 2345.78m, dateOfIncident, dateOfClaim, false);
            _insClaimRepo.AddClaim(updateClaim);
            _insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim);
            Assert.AreEqual(2, _insClaimRepo.GetAllClaims().Count);//Individual Test
            
        }
        [TestMethod]
        public void UpdateClaimTrue()
        {
            InsClaimRepo _insClaimRepo = new InsClaimRepo();
            DateTime dateOfIncident = new DateTime(2021, 03, 07);
            DateTime dateOfClaim = new DateTime(2021, 03, 17);
            _insClaimRepo.AddClaim(ClaimType.Car, "Accident", 2345.78m, dateOfIncident, dateOfClaim);
            InsClaim updateClaim = new InsClaim(1, ClaimType.Car, "Accident number 2", 2345.78m, dateOfIncident, dateOfClaim, false);
            Assert.IsTrue(_insClaimRepo.UpdateClaim(updateClaim, 1));
        }
    }
}
