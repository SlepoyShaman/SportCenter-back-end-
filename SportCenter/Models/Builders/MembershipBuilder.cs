using SportCenter.Models.DataModels;

namespace SportCenter.Models.Builders
{
    public class MembershipBuilder : IBuilder
    {
        private Membership _membership;

        public MembershipBuilder()
        {
            _membership = new Membership();
        }

        public IBuilder AddPool()
        {
            _membership.IsPoolAvailable = true;

            return this;
        }

        public IBuilder AddSauna()
        {
            _membership.IsSaunaAvailable = true;

            return this;
        }

        public IBuilder SetName(string name)
        {
            _membership.Name = name;

            return this;
        }

        public IBuilder SetValidityPeriod(int period)
        {
            _membership.ValidityPeriod = period;

            return this;
        }

        public Membership Build()
        {
            var result = _membership;

            result.DateOfPurchase = DateTime.Now;

            _membership = new Membership();

            return result;
        }
    }
}
