using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Move _move;
        [SerializeField] float _speed = 2;
        [SerializeField, Range(0f, 10f)] float _timeToDisable = 3f;
        [SerializeField] TrailRenderer _trail;

        void OnEnable()
            => _move.enabled = false;

        public void Shoot(Vector3 direction)
        {
            transform.forward = direction;
            _move.enabled = true;
            _move.Velocity = direction * _speed;
            SetTrail(true);
            StartCoroutine(CO_Disable());
        }

        IEnumerator CO_Disable()
        {
            yield return new WaitForSeconds(_timeToDisable);
            SetTrail(false);
            gameObject.SetActive(false);
        }

        void SetTrail(bool enable)
        {
            if (_trail == null) return;
            _trail.enabled = enable;
        }
    }
}