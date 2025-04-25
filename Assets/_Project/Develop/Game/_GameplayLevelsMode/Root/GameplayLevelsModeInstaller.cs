using Player;
using UnityEngine;
using Zenject;

namespace GameplayLevelsMode
{
    public class GameplayLevelsModeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        private void BindFactories()
        {
            //Container.Bind<PlayerFactory>().AsTransient();
            Container.BindFactory<PlayerView, Player.Player, PlayerFactory>().AsTransient();
        }
    }
}