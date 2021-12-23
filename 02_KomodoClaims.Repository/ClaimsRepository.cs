using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private Queue<Claims> _claims;

        public ClaimsRepository()
        {
            _claims = new Queue<Claims>();
        }

        public void CreateNewClaim(Claims claim)
        {
            _claims.Enqueue(claim);
        }

        public Queue<Claims> ViewAllClaims()
        {
            return _claims;

        }

        public Claims ShowNextClaimInLine()
        {
            return _claims.Peek();


        }

        public void DealWithThisClaimNow()
        {
            _claims.Dequeue();
        }

        // Source Stack Overflow - Changed to fit my problem
       // https://stackoverflow.com/questions/4023462/how-do-i-automatically-display-all-properties-of-a-class-and-their-values-in-a-s/4023521
        public string GetProperties(Claims claim)
        {
            var props = claim.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var prop in props)
            {
                sb.Append("| " + prop.Name);
            }
            return sb.ToString();
        }
    }
}
