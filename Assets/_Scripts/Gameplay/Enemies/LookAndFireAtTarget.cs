using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Game.Gameplay.Enemies.PatrolFire;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Gameplay.Enemies
{
    public class LookAndFireAtTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField, Range(0f, 10f)] float _speedRotation = 10f;
        [SerializeField] PatrolFireAnimatorController animController;
        [SerializeField] UnityEvent OnShoot;
        [SerializeField] int _waitForShootInSeconds = 2;
        [SerializeField] float _time = 0;

        void Update()
        {
            var targetDirection = _target.transform.position - transform.position;
            transform.forward = Vector3.Slerp(transform.forward, targetDirection,Time.deltaTime * _speedRotation);
            if (_time < _waitForShootInSeconds)
                _time += 1 * Time.deltaTime;
            else
            {
                OnShoot?.Invoke();
                Debug.Log("Shoot");
                _time = 0;
            }
        }
    }
}
