namespace SportCenter.Models.ExchangeModels
{
    public class GetLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
