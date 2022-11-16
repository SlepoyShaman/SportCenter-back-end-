using SportCenter.Models.Builders;
using SportCenter.Models.DataModels;
using SportCenter.Models.Directors;

namespace SportCenter.Managers
{
    public class MembershipManager
    {
        private Dictionary<MembershipType, AbstractDirector> _directors;
        private IBuilder _builder;
        public MembershipManager(IBuilder builder)
        {
            _builder = builder;

            _directors = new Dictionary<MembershipType, AbstractDirector>() 
            { 
                [MembershipType.Premium] = new PremiumMembershipDirector(_builder),
                [MembershipType.Medium] = new MediumMembershipDirector(_builder),
                [MembershipType.Default] = new DefaultMembershipDirector(_builder)
            };
        }

        public Membership GetMembershipByType(MembershipType type)
        {
            if (!_directors.ContainsKey(type))
                throw new Exception("Недопустимый тип абонемента");

            return _directors[type].GetMembership();
        }
    }
}
