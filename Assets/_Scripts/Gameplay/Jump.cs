using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class Jump : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] float _jumpForce = 10f;
        [SerializeField] LayerMask _floorLayer;
        [SerializeField] GameObject _cheeckFloor;
        [SerializeField, Range(0, 2)] float _floorRadius;
        [SerializeField] float _maxExtraTime = 1;
        bool _onTheFloor = true;
        bool _alreadyJump = false;
        float _extraTime = 0;

        void Update()
        {
            OnTheFloor();
            if (!_onTheFloor && !_alreadyJump)
            {
                _extraTime += 1 * Time.deltaTime;
            }
        }
        public void JumpAction()
        {
            if (_alreadyJump) return;
            if (_onTheFloor || (!_onTheFloor && _extraTime < _maxExtraTime ))
            {
                _alreadyJump = true;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            }
        }
        public void OnTheFloor()
        {
            if (Physics.OverlapSphere(_cheeckFloor.transform.position, _floorRadius, _floorLayer).Length >= 1)
            {
                if (!_onTheFloor)
                {
                    _alreadyJump = false;
                    _extraTime = 0;
                }
                _onTheFloor = true;
            }
            else if (Physics.OverlapSphere(_cheeckFloor.transform.position, _floorRadius, _floorLayer).Length <= 1)
            {
                _onTheFloor = false;
            }
        }
#if UNITY_EDITOR

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_cheeckFloor.transform.position, _floorRadius);
        }
#endif
    }
}






