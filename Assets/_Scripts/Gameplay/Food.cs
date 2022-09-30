using Game.SO;
using UnityEngine;

namespace Game.Gameplay
{
    public class Food : MonoBehaviour
    {
        [SerializeField] IntSO _playerHealt;
        [SerializeField] IntSO _playerMaxHealt;
        int _foot = 10;
        void Start()
        {
            _playerHealt.value = 10;
        }
        void OnTriggerEnter(Collider other)
        {
            if (_playerHealt.value < _playerMaxHealt.value)
            {
                _playerHealt.value += _foot;
                if (_playerHealt.value > _playerMaxHealt.value)
                {
                    _playerHealt = _playerMaxHealt;
                }
                Destroy(gameObject);
            }
        }
    }
}
