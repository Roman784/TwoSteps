using R3;
using UnityEngine;

namespace PlayerInput
{
    public class KeyboardInput : IPlayerInput
    {
        public Subject<Vector2Int> OnReceived { get; } = new();

        public void Handle()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                OnReceived.OnNext(Vector2Int.up);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                OnReceived.OnNext(Vector2Int.down);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                OnReceived.OnNext(Vector2Int.left);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                OnReceived.OnNext(Vector2Int.right);
        }
    }
}