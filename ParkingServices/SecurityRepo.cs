using System.Security.Claims;
using System.Security.Principal;
namespace ParkingServices
{
    public class SecurityRepo : ISecurityRepo
    {
        public bool IsInGroup(ClaimsPrincipal claimsPrincipal, string groupName)
        {
            var user = (WindowsIdentity)claimsPrincipal.Identity;
            if (user.Groups == null) return false;
            foreach (var group in user.Groups)
            {
                if (group.Translate(typeof(NTAccount)).ToString().Contains(groupName))
                    return true;
            }
            return false;
        }
    }
}