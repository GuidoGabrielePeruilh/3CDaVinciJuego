using System;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class EnemyDamageable : MonoBehaviour
    {

        int _enemyLife = 10;
        public Action<int> OnTakeDamage;

        public void TakeTamage(int damage)
        {
            _enemyLife -= damage;
            OnTakeDamage?.Invoke(damage);
        }

    }
}
