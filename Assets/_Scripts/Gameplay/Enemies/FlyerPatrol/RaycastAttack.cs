using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class RaycastAttack : MonoBehaviour
    {
        [SerializeField] int _damage = 1;
        [SerializeField] Transform _firePoint;
        [SerializeField] LayerMask _layerMask;
        [SerializeField, Range(0f, 5f)] float _rateInSeconds = 0;
        [SerializeField] float _maxDistance = 5f;
        float _time;

        public float MaxDistance
        {
            set => _maxDistance = value;
        }
        void LateUpdate()
        {
            if (_time >= _rateInSeconds)
            {
                Attack();
                _time = 0;
            }
            else
            {
                _time += Time.deltaTime;
            }

            var position = _firePoint.transform.position;
            Debug.DrawLine(position, _firePoint.transform.forward.normalized * _maxDistance + position, Color.red);
        }
        void Attack()
        {           
            RaycastHit hit;
            if (Physics.Raycast(_firePoint.transform.position, _firePoint.transform.forward, out hit, _maxDistance, _layerMask))
            {
                hit.collider.GetComponent<IDamageable>()?.TakeTamage(_damage);
            }
        }
    }
}
