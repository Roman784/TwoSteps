using R3;
using UnityEngine;

namespace PlayerInput
{
    public interface IPlayerInput
    {
        public Subject<Vector2Int> OnReceived { get; }
        public void Handle();
    }
}