using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car, Home, Theft}
    public class InsClaim
    {
        public int ID { get; set; }
        public ClaimType Claim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get { return IsClaimValid(DateOfIncident, DateOfClaim); } }
        public bool IsClaimOpen { get; set; }
        public DateTime ClaimCreationDate { get; set; }

        private bool IsClaimValid(DateTime incident, DateTime claim)
        {
            TimeSpan timeSpan = incident - claim;
            int days = Math.Abs(timeSpan.Days);
            return (days <= 30) ? true : false;
        }
        public InsClaim()
        {
            ClaimCreationDate = DateTime.Now;
            IsClaimOpen = true;
        }
        public InsClaim(int id, ClaimType claim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isClaimOpen)
        {
            ID = id;
            Claim = claim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsClaimOpen = isClaimOpen;
            ClaimCreationDate = DateTime.Now;
        }
    }
}
