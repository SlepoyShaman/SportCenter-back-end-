using Microsoft.AspNetCore.Identity;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Identity
{
    public class User : IdentityUser
    {
        public int MembershipId { get; set; }
        public Membership Membership { get; set; } 
    }
}
