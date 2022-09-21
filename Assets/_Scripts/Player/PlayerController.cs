using Game.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] Move _move;
        public void Move(InputAction.CallbackContext context)
        {
            var Movement =context.ReadValue<Vector2>();
            
            
        }
    }
}