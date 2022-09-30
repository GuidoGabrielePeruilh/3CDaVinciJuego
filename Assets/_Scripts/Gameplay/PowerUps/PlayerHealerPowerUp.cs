using Game.SO;
using UnityEngine;

namespace Game.Gameplay.PowerUps
{
    public class PlayerHealerPowerUp : MonoBehaviour
    {
        [SerializeField] IntSO _playerHealth;
        [SerializeField] IntSO _playerMaxHealth;
        int _healingPower = 10;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (_playerHealth.value >= _playerMaxHealth.value) return;

            _playerHealth.value += _healingPower;
            if (_playerHealth.value > _playerMaxHealth.value)
            {
                _playerHealth = _playerMaxHealth;
            }
            Destroy(gameObject);
        }
    }
}
