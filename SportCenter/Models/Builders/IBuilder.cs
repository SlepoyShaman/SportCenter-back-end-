using SportCenter.Models.DataModels;

namespace SportCenter.Models.Builders
{
    public interface IBuilder
    {
        public IBuilder AddPool();
        public IBuilder AddSauna();
        public IBuilder SetName(string name);
        public IBuilder SetValidityPeriod(int period);
        public Membership Build();
    }
}
