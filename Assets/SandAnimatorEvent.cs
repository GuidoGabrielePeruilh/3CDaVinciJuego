using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class SandAnimatorEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent OnGrabBullet, OnShootBullet;

        public void GrabBullet()
            => OnGrabBullet?.Invoke();

        public void ShootBullet()
            => OnShootBullet?.Invoke();
    }
}
