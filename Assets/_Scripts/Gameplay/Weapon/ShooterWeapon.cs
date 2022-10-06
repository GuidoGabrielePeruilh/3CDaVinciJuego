using Game.SO;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class ShooterWeapon : Weapon
    {
        [SerializeField]
        protected WeaponSO _weaponData;

        [SerializeField]
        protected ObjectPooler _bulletPooler;

        [SerializeField]
        protected Transform _firePoint;

        protected Vector3 ShootDirection
            => (Target - _firePoint.transform.position).normalized;
        protected abstract void Shoot();
    }
}