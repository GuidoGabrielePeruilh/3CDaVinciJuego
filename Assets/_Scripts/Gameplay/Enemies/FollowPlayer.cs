using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class FollowPlayer : MonoBehaviour
    {          
        [SerializeField, Range(0,5)]  float _speed = 5;        
        [SerializeField] Move _move;
        [SerializeField, Range(0f, 5f)] float _closeRange = 2f;
        [SerializeField, Range(.1f, 3f)] float _rangeOfVisionY = 1;
        PlayerController _player;
        public float CloseRange => _closeRange;
        public float RangeOfVisionY
        {
            set => _rangeOfVisionY = value;
        }
        
        public float Speed
        {
            set => _speed = value;
        }

        void Awake()
        {
            _player = FindObjectOfType<PlayerController>();          
        }
        void Update()
        {
            var playerPosition = _player.transform.position;
            var currentPosition = transform.position;
            if (Utils.IsInRangeOfVision(currentPosition, playerPosition, _closeRange, _rangeOfVisionY))
            {
                _move.Velocity = Vector3.zero;
            }
            else
            {
                _move.Velocity = (playerPosition - currentPosition).normalized * _speed;
            }
        }
    }
}
