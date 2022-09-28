using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class CameraFollowTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;

        private void Awake()
        {
            transform.forward = _target.transform.forward;
        }

        void LateUpdate()
        {
            transform.position = _target.transform.position;
        }
    }
}
