using System.Collections.Generic;

namespace _02_KomodoClaims.Repository
{
    public interface IClaimsRepository
    {
        void CreateNewClaim(Claims claim);
        void DealWithThisClaimNow();
        Claims ShowNextClaimInLine();
        Queue<Claims> ViewAllClaims();

        string GetProperties(Claims claim);
    }
}