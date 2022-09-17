using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] int _range = 100;
        Player _player;
        float _distanceFromPlayer;
        [SerializeField, Range(0,5)]  float _speed = 3;
        Vector3 _direction;
        [SerializeField] Move _move;
        

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            
        }

        void Update()
        {
            MoveEnemyDistance();
            
        }
        public void MoveEnemyDistance()
        {
            CheckDistanceFromPlayer();
            if (_distanceFromPlayer >= _range)
            {
                _move.Velocity = (_player.transform.position - transform.position).normalized * _speed;
            }
            else
            {
                _move.Velocity = Vector3.zero;

            }

        }
        void CheckDistanceFromPlayer()
        {

            _distanceFromPlayer = Vector3.Distance(transform.position, _player.transform.position);
            Debug.Log(_distanceFromPlayer);

        }
        

        
    }
}
