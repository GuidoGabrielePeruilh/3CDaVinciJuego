using Game.SO;
using System.Collections;
using System.Collections.Generic;
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
            //_playerMaxHealt.value = 
            _playerHealt.value = 10;
        }
        void OnTriggerEnter(Collider other)
        {
            
            if (_playerHealt.value < _playerMaxHealt.value)
            {
                _playerHealt.value += _foot;
                Debug.Log("te curaste 10 de vida cabron ");
                Destroy(gameObject);
                if (_playerHealt.value > _playerMaxHealt.value)
                {
                    _playerHealt = _playerMaxHealt;
                }
            }
        }
    }
}
