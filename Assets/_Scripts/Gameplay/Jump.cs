using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class Jump : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] float _jumpForce = 10f;
        [SerializeField] int _floorLayer;
        [SerializeField, Range(0, 2)] float _floorRadius;
        bool _onTheFloor = true;
        [SerializeField, Range(0f, 2f)] float _maxExtraTime;
        float _extraTime = 0;
        bool _alreadyJump = false;

        void Awake()
        {
            transform.localScale = new Vector3(_floorRadius, _floorRadius, _floorRadius);
        }

        void Update()
        {
            if (!_onTheFloor && !_alreadyJump)
            {
                _extraTime += 1 * Time.deltaTime;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            // if (other.gameObject.layer != _floorLayer) return;

            _alreadyJump = false;
            _onTheFloor = true;
        }

        void OnTriggerExit(Collider other)
        {
            // if (other.gameObject.layer != _floorLayer) return;

            _onTheFloor = false;
            _extraTime = 0;
        }

        public void JumpAction()
        {
            if ((_onTheFloor || _extraTime < _maxExtraTime) && !_alreadyJump)
            {
                _alreadyJump = true;
                _onTheFloor = false;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}
