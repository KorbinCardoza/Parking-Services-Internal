using System.Security.Claims;

namespace ParkingServices
{
    public interface ISecurityRepo
    {
     bool IsInGroup(ClaimsPrincipal claimsPrincipal, string groupName);
     }
    }


