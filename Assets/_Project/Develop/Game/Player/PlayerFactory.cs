using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFactory : PlaceholderFactory<PlayerView, Player>
    {
        private readonly TickableManager _tickableManager;

        [Inject]
        public PlayerFactory(TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
        }

        public override Player Create(PlayerView viewRefab)
        {
            var view = Object.Instantiate(viewRefab);
            var newPlayer = base.Create(view);

            _tickableManager.Add(newPlayer);

            return newPlayer;
        }
    }
}