using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ParkingServices
{
    public class CheckADGroupRequirement : IAuthorizationRequirement
    {
        public string GroupName { get; private set; }

        public CheckADGroupRequirement(string groupName)
        {
            GroupName = groupName;
        }
    }
}