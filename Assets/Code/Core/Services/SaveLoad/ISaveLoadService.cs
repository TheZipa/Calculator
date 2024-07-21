using Core.Data.Progress;

namespace Core.Services.SaveLoad
{
    public interface ISaveLoadService : IGlobalService
    {
        Progress Progress { get; }
        void Load();
        void Save();
    }
}