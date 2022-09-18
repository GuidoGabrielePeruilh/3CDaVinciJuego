using System;
using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class PatrolFireAnimatorController : MonoBehaviour
    {
        [SerializeField] Move _move;
        [SerializeField] Animator _animator;

        void LateUpdate()
        {
            _animator.SetFloat("Speed", _move.Velocity.magnitude);
        }

        public void ShootAnimation()
            => _animator.SetTrigger("Attack");
    }
}