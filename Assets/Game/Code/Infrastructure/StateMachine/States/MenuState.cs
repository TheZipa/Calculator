using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.EntityContainer;
using Game.Code.Services.LoadingCurtain;
using Game.Code.Services.SceneLoader;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;
        
        private const string MenuScene = "Calculator";

        public MenuState(IGameStateMachine stateMachine,
            ISceneLoader sceneLoader, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter() => _sceneLoader.LoadScene(MenuScene, PrepareMenu);

        public void Exit()
        {
            
        }

        private void PrepareMenu()
        {
            Subscribe();
            _loadingCurtain.Hide();
        }

        private void Subscribe()
        {
           
        }

        private void LoadGame() => _stateMachine.Enter<LoadGameState>();
    }
}