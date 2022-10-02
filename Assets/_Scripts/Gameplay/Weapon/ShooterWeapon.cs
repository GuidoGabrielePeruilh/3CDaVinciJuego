using Game.Player;
using Game.SO;
using Game.Managers;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class ShooterWeapon : Weapon
    {
        [SerializeField] WeaponSO _weaponData;
        [SerializeField] ObjectPooler _bulletPooler;
        [SerializeField] Transform _firePoint;
        int _bullets = 0;
        int _reserveBullets = 0;

        public override int CurrentAmmunition => _bullets;
        void Awake()
        {
            type = Type.SHOOTER;
            _bullets = _weaponData.MaxBullets;
            _reserveBullets = _weaponData.MaxReserveBullets;
        }

        public override bool CanAttack()
        {
            return _bullets > 0;
        }

        public override void Attack()
        {
            var bulletObject = _bulletPooler.GetPooledObject();
            bulletObject.transform.position = _firePoint.position;
            bulletObject.SetActive(true);
            bulletObject.GetComponent<Bullet>()?.Shoot(_firePoint.forward);
            _bullets--;
            GameManager.instance.UpdateBulletCounter(this);
        }

        public override bool ReloadWeapon()
        {
            if (_reserveBullets <= 0) return false;
            if (_reserveBullets >= _weaponData.MaxBullets)
            {
                _reserveBullets -= _weaponData.MaxBullets;
                _bullets += _weaponData.MaxBullets;
            }
            else
            {
                _bullets = _reserveBullets;
                _reserveBullets = 0;
            }
            return true;
        }

        public override bool ReloadReserve()
        {
            if (_reserveBullets >= _weaponData.MaxReserveBullets)
                return false;

            _reserveBullets = _weaponData.MaxReserveBullets;
            return true;
        }

        public override void SubscribeToAnimationEvents(PlayerAnimationManager animationManager)
        {
            animationManager.ADD_ANI_EVENT("pistol_shooting_event", EVENT_PISTOL_SHOOTING);
        }
        
        void EVENT_PISTOL_SHOOTING()
        {
            Attack();
        }
    }
}