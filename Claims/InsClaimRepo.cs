using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class InsClaimRepo
    {
        protected readonly List<InsClaim> _insClaims = new List<InsClaim>();
        public bool AddClaim(ClaimType claim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            int id = _insClaims.Count+1;
            InsClaim newClaim = new InsClaim(id, claim, description, claimAmount, dateOfIncident, dateOfClaim, true);
            _insClaims.Add(newClaim);

            return (id == _insClaims.Count) ? true : false;
        }
        public bool AddClaim(InsClaim claim)
        {
            int count = _insClaims.Count;
            int id = _insClaims.Count + 1;
            claim.ID = id;
            _insClaims.Add(claim);
            return (_insClaims.Count == count + 1) ? true : false;
        }
        public InsClaim GetClaim(int x)
        {
            foreach (InsClaim item in _insClaims)
            {
                if (item.ID == x)
                {
                    return item;
                }
            }
            return null;
        }
        public InsClaim GetNextClaim()
        {
            foreach (InsClaim item in GetAllOpenClaims())
            {
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }
        public List<InsClaim> GetAllClaims()
        {
            return _insClaims;
        }
        public List<InsClaim> GetAllOpenClaims()
        {
            List<InsClaim> openClaims = new List<InsClaim>();
            foreach (InsClaim item in _insClaims)
            {
                if (item.IsClaimOpen)
                {
                    openClaims.Add(item);
                }
            }
            return openClaims;
        }
        public bool UpdateClaim(InsClaim insClaim, int x)
        {
            InsClaim targetClaim = GetClaim(x);
            targetClaim.Claim = insClaim.Claim;
            targetClaim.Description = insClaim.Description;
            targetClaim.ClaimAmount = insClaim.ClaimAmount;
            targetClaim.DateOfIncident = insClaim.DateOfIncident;
            targetClaim.DateOfClaim = insClaim.DateOfClaim;
            targetClaim.IsClaimOpen = insClaim.IsClaimOpen;

            return (targetClaim.Description == insClaim.Description) ? true : false;
        }
    }
}
