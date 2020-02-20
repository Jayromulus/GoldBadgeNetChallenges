using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoClaimsRepo
{
    public class KomodoClaimsRepo
    {
        private List<Claim> _claimRepo = new List<Claim>();

        public bool AddContentToDirectory(Claim newClaim)
        {
            int dirLength = _claimRepo.Count();
            _claimRepo.Add(newClaim);
            bool wasAdded = dirLength + 1 == _claimRepo.Count();

            return wasAdded;
        }

        public bool RemoveFirstClaim()
        {
            int dirLength = _claimRepo.Count();
            var first = _claimRepo[0];
            _claimRepo.RemoveAt(0);
            bool wasRemoved = dirLength - 1 == _claimRepo.Count();
            bool wasFirst = false;
            if(_claimRepo.Count > 0)
            {
                wasFirst = first.ClaimID != _claimRepo[0].ClaimID;
            }
            else
            {
                wasFirst = true;
            }
            bool removedSuccessfully = wasRemoved && wasFirst;

            return removedSuccessfully;
        }

        public List<Claim> GetAllClaims()
        {
            return _claimRepo;
        }
    }
}
