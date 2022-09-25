using Game.Gameplay;
using UnityEngine;

namespace Game
{
    public class DummyBorrar : MonoBehaviour
    {
        [SerializeField] Transform _bPoint;
        [SerializeField] Transform _aPoint;
        float _way = 0f;
        float _target = 1f;
        float _direction = 1;
        int damage = 10;

        void Update()
        {
            transform.position = Vector3.Lerp(_aPoint.position, _bPoint.position, _way);
            if (_target == 0 && _way <= _target)
            {
                _target = 1;
                _direction = 1;
            }

            if (_target == 1 && _way >= _target)
            {
                _target = 0;
                _direction = -1;
            }
            _way += _direction * Time.deltaTime;
        }

        void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IDamageable>()?.TakeTamage(damage);
            Debug.Log(damage);
        }
    }
}
