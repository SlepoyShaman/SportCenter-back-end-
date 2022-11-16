using SportCenter.Models.Builders;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Directors
{
    public class PremiumMembershipDirector : AbstractDirector
    {
        private readonly IBuilder _builder;
        public PremiumMembershipDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public override Membership GetMembership() =>
            _builder.SetName("Premium абонемент")
            .SetValidityPeriod(120)
            .AddPool()
            .AddSauna()
            .Build();
    }
}
