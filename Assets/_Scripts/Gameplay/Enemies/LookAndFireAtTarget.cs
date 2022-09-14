using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class LookAndFireAtTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;

        void Update()
        {
            transform.LookAt(_target.transform);
        }
    }
}
