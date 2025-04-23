using Zenject;

namespace GameRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsTransient();
        }
    }
}