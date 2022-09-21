using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class MetalEnemyAC : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] Move _move;
       
        private void Update()
        {
            _animator.SetFloat("Speed", _move.Velocity.magnitude);
        }
        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }

    }
}
