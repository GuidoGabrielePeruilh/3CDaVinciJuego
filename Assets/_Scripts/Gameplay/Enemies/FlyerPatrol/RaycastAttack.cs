using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class RaycastAttack : MonoBehaviour
    {
        [SerializeField] int _damage = 1;
        [SerializeField] Transform _firePoint;
        [SerializeField] LayerMask _layerMask;

        private void LateUpdate()
        {
            Attack();
        }
        void Attack()
        {           
            RaycastHit hit;
            if (Physics.Raycast(_firePoint.transform.position, _firePoint.transform.forward, out hit, 20, _layerMask))
            {
                hit.collider.GetComponent<IDamageable>()?.TakeTamage(_damage);
                Debug.Log("atacand!!!!" + hit.collider.gameObject.name);
            }
        }
    }
}
