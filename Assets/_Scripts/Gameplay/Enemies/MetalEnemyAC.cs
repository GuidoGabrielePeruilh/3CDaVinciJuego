using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class MetalEnemyAC : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] Move _move;

        void Update()
        {
            _animator.SetFloat("Speed", _move.Velocity.magnitude);
        }      
    }
}
