using System;
using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class PatrolBehaviour : MonoBehaviour
    {
        [SerializeField] Move _move;
        [SerializeField, Range(.1f, 5f)] float _speed = 2f;
        [SerializeField] float _waitBetweenPointInSeconds = 1f;
        [SerializeField] float _waitOnEnable = 2.5f;

        [Tooltip("The order of the points will be the order in which it is patrolled. ('Has to bi bigger than one')")]
        [SerializeField] private List<GameObject> _waypoints;
        [SerializeField, Range(0f, 5f)] float _minimumDistanceNearPoint;
        [Tooltip("If is active, it will go through the points in cycles. If is NOT, it will go back and forth.")]
        [SerializeField] bool _cycle = false;

        [Space]
        [SerializeField, Range(0f, 5f)] float _pointRadiusGizmos = 2f;
        [SerializeField] Color _sphereColor = Color.red;
        [SerializeField] Color _lineColor = Color.green;

        Vector3[] _patrol;
        int _target = 0;
        int _direction = 1;
        bool _isWaiting = false;
        WaitForSeconds _waitForSeconds;
        WaitForSeconds _waitForSecondsOnEnable;

        void Awake()
        {
            _patrol = new Vector3[_waypoints.Count];
            for (int i = 0; i < _waypoints.Count; i++)
            {
                var transformPosition = _waypoints[i].transform.position;
                _patrol[i] = new Vector3(transformPosition.x, 0, transformPosition.z);
            }
            transform.position = _patrol[0];
            _target = 1;
            _waitForSeconds = new WaitForSeconds(_waitBetweenPointInSeconds);
            _waitForSecondsOnEnable = new WaitForSeconds(_waitOnEnable);
        }

        void OnEnable()
        {
            StartCoroutine(CO_StartWaiting(_waitForSecondsOnEnable));
        }

        void Update()
        {
            if (_isWaiting) return;

            var targetPosition = _patrol[_target];
            transform.LookAt(targetPosition);
            var transformPosition = new Vector3(transform.position.x, 0, transform.position.z);
            _move.Velocity = (targetPosition - transformPosition).normalized * _speed;
            if (Vector3.Distance(transformPosition, targetPosition) <= _minimumDistanceNearPoint)
            {
                if (_cycle)
                {
                    if (_direction > 0 && _target == _patrol.Length - 1)
                        _target = -1;
                    else if (_direction < 0 && _target == 0)
                        _target = _patrol.Length;
                }
                else
                {
                    if (_target == _patrol.Length - 1 || _target == 0)
                        ChangeDirection();
                }
                _target += _direction;
                StartCoroutine(CO_StartWaiting(_waitForSeconds));
            }
        }

        IEnumerator CO_StartWaiting(WaitForSeconds waitForSeconds)
        {
            _isWaiting = true;
            _move.Velocity = Vector3.zero;
            yield return waitForSeconds;
            _isWaiting = false;
        }

        void ChangeDirection()
        {
            _direction *= -1;
        }

        void OnDrawGizmos()
        {
            for (int i = 0; i < _waypoints.Count; i++)
            {
                var currentPosition = _waypoints[i].transform.position;
                Gizmos.color = _sphereColor;
                Gizmos.DrawSphere(currentPosition, _pointRadiusGizmos);
                var nextIdex = i == _waypoints.Count - 1? 0 : i + 1;
                
                if (nextIdex == 0 && !_cycle) return;
                
                var nextPosition = _waypoints[nextIdex].transform.position;
                Gizmos.color = _lineColor;
                Gizmos.DrawLine(currentPosition, nextPosition);
            }
        }
    }
}
