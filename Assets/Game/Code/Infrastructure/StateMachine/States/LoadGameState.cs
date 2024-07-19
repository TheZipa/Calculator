using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.EntityContainer;
using Game.Code.Services.LoadingCurtain;
using Game.Code.Services.SceneLoader;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private const string GameScene = "Game";

        public LoadGameState(IGameStateMachine gameStateMachine,
            IEntityContainer entityContainer, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(GameScene, CreateGame);
        }

        public void Exit()
        {
        }

        private async void CreateGame()
        {
            FinishLoad();
        }
        private void FinishLoad() => _gameStateMachine.Enter<GameplayState>();
    }
}