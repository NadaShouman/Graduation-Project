using System.Security.Claims;

namespace AbilitySystem.API.Controllers.Registeration
{
    public interface IHelper
    {
        public string GenerateToken(IList<Claim> claimsList, DateTime exp);
    }
}
