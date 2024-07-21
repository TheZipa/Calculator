using Core.Data.Progress;
using Core.Extensions;
using UnityEngine;

namespace Core.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        public Progress Progress { get; private set; }
        private const string ProgressKey = "Progress";
        
        public void Load()
        {
            string progressJson = PlayerPrefs.GetString(ProgressKey);
            Progress = progressJson.ToDeserialized<Progress>() ?? new Progress();
        }

        public void Save()
        {
            PlayerPrefs.SetString(ProgressKey, Progress.ToJson());
        }
    }
}