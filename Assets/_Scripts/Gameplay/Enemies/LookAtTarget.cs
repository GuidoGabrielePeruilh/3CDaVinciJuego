using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Gameplay.Enemies
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField, Range(0f, 10f)] float _speedRotation = 10f;
        public GameObject Target => _target; 
        

        void Update()
        {
            var targetDirection = _target.transform.position - transform.position;
            transform.forward = Vector3.Slerp(transform.forward, targetDirection,Time.deltaTime * _speedRotation);
        }

    }
}
