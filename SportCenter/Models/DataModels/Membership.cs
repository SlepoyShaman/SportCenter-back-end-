using SportCenter.Models.Identity;

namespace SportCenter.Models.DataModels
{
    public class Membership : IWithId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int ValidityPeriod { get; set; } = 0;
        public bool IsPoolAvailable { get; set; } = false;
        public bool IsSaunaAvailable { get; set; } = false;
        public User? User { get; set; }

    }

    public enum MembershipType
    {
        Premium = 0,
        Medium = 1,
        Default = 2
    }
}
