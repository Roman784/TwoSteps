using PlayerInput;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Player : ITickable
    {
        private readonly PlayerView _view;

        private IPlayerInput _input;

        [Inject]
        public void Construct(IPlayerInput input)
        {
            _input = input;
        }

        public Player(PlayerView view)
        {
            _view = view;
        }

        public void Tick()
        {
            _input.Handle();
        }
    }
}