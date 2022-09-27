using Game.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Move _move;
        [SerializeField] Jump _jump;
        [SerializeField] AttackPjMelee _melee;
        [SerializeField, Range(0,10)] private float _speed = 2;

        public void Move(InputAction.CallbackContext context)
        {
           var input = context.ReadValue<Vector2>();
            _move.Velocity = new Vector3(input.x, 0, input.y).normalized * _speed;
        }

       public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _jump.JumpAction();
            }
        }
        
        
        
    }
}