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
            Debug.Log("Shoot");
            //TODO shoot bullet
            var forwardNormalized = (_target.transform.position - transform.position).normalized;
            _currentBullet.GetComponent<Rigidbody>()?.AddForce(forwardNormalized, ForceMode.VelocityChange);
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