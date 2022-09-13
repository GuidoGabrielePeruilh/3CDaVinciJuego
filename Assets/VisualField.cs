using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class VisualField : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField] float _visualAngle = 45f;
        [SerializeField] float _visualDistance = 10f;
        // [SerializeField] UnityEvent OnEnterViewTarget, OnExitViewTarget, OnStayViewTarget;
        // public Action OnEnterViewTarget, OnExitViewTarget, OnStayViewTarget;
        bool CanSeeTarget()
        {
            if (Vector3.Distance(_target.transform.position, transform.position) > _visualDistance) return false;
            var direction = _target.transform.position - transform.position;
            if (Vector3.Angle(direction, transform.forward) > _visualAngle) return false;

            return true;
        }
        
    }
}
