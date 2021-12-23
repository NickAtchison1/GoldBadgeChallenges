using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims.Repository
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
        
    }
    public class Claims
    {
        static int _claimId = 1;
        private DateTime _dateOfClaim = DateTime.Now.Date;
       // private bool _isValid;

        public Claims()
        {
            ClaimID = _claimId++;
            DateOfClaim = _dateOfClaim;
            
        }

        public Claims(ClaimType claimType, string desciption, decimal claimAmount, DateTime dateOfIncident)
        {
            ClaimType = claimType;
            Desription = desciption;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            
        }

        public int ClaimID { get; private set; }
        public ClaimType ClaimType { get; set; }
        public string Desription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; private set; }

        public bool IsValid
        {
            get
            {
                TimeSpan numberDaysSinceIncident = DateOfClaim.Date - DateOfIncident.Date;
                if ((int)Math.Floor(numberDaysSinceIncident.TotalDays) > 30)
                    return false;
                else return true;
            }
        }
    }
}
