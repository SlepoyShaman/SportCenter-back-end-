using SportCenter.Models.Builders;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Directors
{
    public class MediumMembershipDirector : AbstractDirector
    {
        private readonly IBuilder _builder;
        public MediumMembershipDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public override Membership GetMembership() =>
            _builder.SetName("Medium абонемент")
            .SetValidityPeriod(180)
            .AddPool()
            .Build();
        
    }
}
