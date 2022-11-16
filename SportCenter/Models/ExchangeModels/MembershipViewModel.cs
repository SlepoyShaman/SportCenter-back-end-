namespace SportCenter.Models.ExchangeModels
{
    public class MembershipViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DaysToBurn { get; set; }
        public bool IsPoolAvailable { get; set; } = false;
        public bool IsSaunaAvailable { get; set; } = false;
    }
}
