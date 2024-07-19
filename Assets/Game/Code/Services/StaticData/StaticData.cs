using Game.Code.Services.StaticData.StaticDataProvider;

namespace Game.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        public void LoadStaticData()
        {
            
        }
    }
}