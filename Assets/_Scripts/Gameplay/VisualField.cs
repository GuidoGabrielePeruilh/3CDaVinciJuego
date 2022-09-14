using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Gameplay
{
    public class VisualField : MonoBehaviour
    {
        public event Action<GameObject> OnEnterViewTarget, OnExitViewTarget, OnStayViewTarget;

        [SerializeField] GameObject _target;
        [SerializeField] float _visualAngle = 45f;
        [SerializeField] float _visualDistance = 10f;
        bool _isTargetInView = false;

        void Update()
        {
            if (CanSeeTarget())
            {
                if (!_isTargetInView)
                {
                    OnEnterViewTarget?.Invoke(_target);
                    _isTargetInView = true;
                }
            }
            else
            {
                if (_isTargetInView)
                {
                    OnExitViewTarget?.Invoke(_target);
                    _isTargetInView = false;
                }
            }
        }

        public bool IsTargetInView => _isTargetInView;
        
        bool CanSeeTarget()
        {
            if (Vector3.Distance(_target.transform.position, transform.position) > _visualDistance) return false;
            var direction = (_target.transform.position - transform.position).normalized;
            var angle = Vector3.Angle(transform.forward, direction);
            Debug.Log(angle);
            if (angle > _visualAngle / 2) return false;

            return true;
        }

        void OnDrawGizmos()
        {
            Handles.color = Color.white;
            var transformPosition = transform.position;
            Handles.DrawWireArc(transformPosition, Vector3.up, Vector3.forward, 360, _visualDistance);
            // Handles.DrawWireArc(transformPosition, Vector3.up, Vector3.forward, -_visualAngle / 2, _visualDistance);
            var viewAngleLeft = DirectionFromAngle(transform.eulerAngles.y, -_visualAngle / 2);
            var viewAngleRight = DirectionFromAngle(transform.eulerAngles.y, _visualAngle / 2);
            Handles.color = Color.yellow;
            Handles.DrawLine(transformPosition, transformPosition + viewAngleLeft * _visualDistance);
            Handles.DrawLine(transformPosition, transformPosition + viewAngleRight * _visualDistance);
        }
        Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;
        
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
