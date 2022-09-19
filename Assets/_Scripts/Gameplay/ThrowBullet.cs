using System;
using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class ThrowBullet : MonoBehaviour
    {
        [SerializeField] Transform _firePoint;
        [SerializeField] ObjectPooler _bulletPooler;
        GameObject _currentBullet;
        GameObject _target;
        [SerializeField] float _addHighToTarget = 1.5f;

        public GameObject Target
        {
            set => _target = value;
        }
        public void GrabBullet()
        {
            _currentBullet = _bulletPooler.GetPooledObject();
            _currentBullet.SetActive(true);
            StartCoroutine(CO_GrabBulletAction());
        }
        public void ShootBullet()
        {
            _currentBullet.transform.parent = null;
            var component = _currentBullet.GetComponent<Bullet>();
            var transformPosition = _target.transform.position;
            if (_addHighToTarget > 0)
                transformPosition.y = _addHighToTarget;
            var forwardNormalized = (transformPosition - _firePoint.transform.position).normalized;
            component.Shoot(forwardNormalized);
            _currentBullet = null;
        }
        IEnumerator CO_GrabBulletAction()
        {
            while (_currentBullet != null)
            {
                _currentBullet.transform.position = _firePoint.transform.position;
                yield return null;
            }
        }
    }
}