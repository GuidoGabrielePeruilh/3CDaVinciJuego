using System;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] int _enemyLife = 10;
        [SerializeField] int _secondsToDestroy = 3;
        public event Action<int> OnTakeDamage;
        public event Action OnDeath;
        public int Life => _enemyLife;

        public void TakeTamage(int damage)
        {                      
            if (Life <= 0) return;

            _enemyLife -= damage;
            OnTakeDamage?.Invoke(damage);
            if (Life <= 0)
            {               
                OnDeath?.Invoke();
                Destroy(gameObject, _secondsToDestroy);
            }
        }
    }
}
