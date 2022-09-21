using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Move _move;
        [SerializeField] float _speed = 2;
        [SerializeField, Range(0f, 10f)] float _timeToDisable = 3f;

        void OnEnable()
            => _move.enabled = false;

        public void Shoot(Vector3 direction)
        {
            _move.enabled = true;
            _move.Velocity = direction * _speed;
            StartCoroutine(CO_Disable());
        }

        IEnumerator CO_Disable()
        {
            yield return new WaitForSeconds(_timeToDisable);
            gameObject.SetActive(false);
        }
    }
}