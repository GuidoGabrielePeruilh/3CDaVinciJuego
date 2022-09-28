using System;
using UnityEngine;
using System.Collections;

namespace Game.Gameplay.Enemies
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {

        [SerializeField]int _enemyLife = 10;
        [SerializeField] int _secondsToDestroy = 3;
        public event Action<int> OnTakeDamage;
        public event Action OnDeath;
        public int Life => _enemyLife;

        public void TakeTamage(int damage)
        {
            _enemyLife -= damage;
            OnTakeDamage?.Invoke(damage);
            if (Life <= 0)
            {
                OnDeath?.Invoke();
                StartCoroutine(CO_Destroy());
            }
        }
        IEnumerator CO_Destroy()
        {
            yield return new WaitForSeconds(_secondsToDestroy);
            Destroy(transform.parent.gameObject);
        }

        

    }
}
