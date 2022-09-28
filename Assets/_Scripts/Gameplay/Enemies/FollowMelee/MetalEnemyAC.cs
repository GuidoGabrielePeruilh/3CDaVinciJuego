using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class MetalEnemyAC : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] EnemyDamageable _enemyDamagable;
        [SerializeField] Move _move;

        private void Awake()
        {
            _enemyDamagable.OnDeath += Death;
        }
        private void Update()
        {
            _animator.SetFloat("Speed", _move.Velocity.magnitude);

        }
        public void Attack()
        {
            _animator.SetTrigger("Attack");
        }
        public void Death()
        {
            _animator.SetTrigger("Death");
        }
    }
}
