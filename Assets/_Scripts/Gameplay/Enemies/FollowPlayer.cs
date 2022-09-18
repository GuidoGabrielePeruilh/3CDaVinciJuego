using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class FollowPlayer : MonoBehaviour
    {          
        Player _player;        
        [SerializeField, Range(0,5)]  float _speed = 3;        
        [SerializeField] Move _move;
        

        void Awake()
        {
            _player = FindObjectOfType<Player>();          
        }
        void Update()
        {
            _move.Velocity = (_player.transform.position - transform.position).normalized * _speed;
        }
    }
}
