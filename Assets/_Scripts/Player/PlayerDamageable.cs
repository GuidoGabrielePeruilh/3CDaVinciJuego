using System;
using Game.Gameplay;
using Game.SO;
using Game.Managers;
using UnityEngine;

namespace Game.Player
{
    public class PlayerDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] IntSO _playerLive;
        public Action<int> OnTakeDamage;

        public void TakeTamage(int damage)
        {
            _playerLive.value -= damage;
            OnTakeDamage?.Invoke(damage);

            if (_playerLive.value <= 0)
                GameManager.instance.DeathScreen();
        }
    }
}