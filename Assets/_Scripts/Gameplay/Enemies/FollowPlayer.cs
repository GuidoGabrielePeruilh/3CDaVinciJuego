using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class FollowPlayer : MonoBehaviour
    {          
        [SerializeField, Range(0,5)]  float _speed = 3;        
        [SerializeField] Move _move;
        [SerializeField, Range(0f, 5f)] float _closeRange = 2f;
        PlayerController _player;        
        public float CloseRange => _closeRange;
        

        void Awake()
        {
            _player = FindObjectOfType<PlayerController>();          
        }
        void Update()
        {
            if (Vector3.Distance(_player.transform.position, transform.position) <= _closeRange)
            {
                _move.Velocity = Vector3.zero;
            }
            else
            {
                _move.Velocity = (_player.transform.position - transform.position).normalized * _speed;
            }
        }

        public float Speed
        {
            set => _speed = value;
        }
    }
}
