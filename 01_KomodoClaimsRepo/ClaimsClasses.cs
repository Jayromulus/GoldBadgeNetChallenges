using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoClaimsRepo
{
    public class Claim
    {
        Random rnd = new Random();
        public Claim() { }
        public Claim(int id, string type, string desc, string amount, string dateOfAccident, string dateOfClaim, bool valid)
        {
            ClaimID = id;
            Type = type;
            Description = desc;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = valid;
        }

        public int ClaimID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string DateOfAccident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }



    }
}
