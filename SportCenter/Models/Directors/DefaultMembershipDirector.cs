using SportCenter.Models.Builders;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Directors
{
    public class DefaultMembershipDirector : AbstractDirector
    {
        private readonly IBuilder _builder;
        public DefaultMembershipDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public override Membership GetMembership() =>
            _builder.SetName("Стандартный абонемент")
            .SetValidityPeriod(30)
            .Build();
    }
}
