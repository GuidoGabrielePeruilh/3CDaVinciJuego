using Game.SO;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class ShooterWeapon : Weapon
    {
        [SerializeField] WeaponSO _weaponData;
        [SerializeField] ObjectPooler _bulletPooler;
        [SerializeField] Transform _firePoint;
        int _bullets = 0;

        [ContextMenu("ShootBullet")]
        public override void ShootBullet()
        {
            var bulletObject = _bulletPooler.GetPooledObject();
            bulletObject.SetActive(true);
            bulletObject.transform.position = _firePoint.position;
            bulletObject.GetComponent<Bullet>()?.Shoot(_firePoint.forward);
        }

        public override void ReloadWeapon()
        {
            _bullets = _weaponData.MaxBullets;
        }
    }
    // public class 
}