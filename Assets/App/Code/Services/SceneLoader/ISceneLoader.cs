using System;

namespace Services.App.Code.Services.SceneLoader
{
    public interface ISceneLoader : IGlobalService
    {
        void LoadScene(string sceneName, Action onLoaded = null);
    }
}