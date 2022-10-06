using Game.Managers;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class ParticleWeapon : ShooterWeapon
    {
        [SerializeField] GameObject _particle;
        bool _isShooting = false;
        float _time;
        
        void Awake()
        {
            _time = attackRateInSeconds;
            Ammunition = _weaponData.MaxAmunicion;
            _particle.SetActive(false);
        }

        void Update()
        {
            if (_isShooting)
            {
                if (_time <= 0)
                {
                    Shoot();
                    _time = attackRateInSeconds;
                    Ammunition--;
                    GameManager.instance.UpdateBulletCounter(Ammunition);
                    if(Ammunition <= 0)
                    {
                        CancelAttack();
                    }
                }
                else
                {
                    _time -= Time.deltaTime;
                }
            }
        }
        #region public
        public override void StartAttack()
        {
            if (Ammunition <= 0) return;
            _particle.SetActive(true);
            _isShooting = true;
        }

        public override void PerformedAttack(){ }

        public override void CancelAttack()
        {
            _particle.SetActive(false);
            _isShooting = false;
        }

        public override bool ReloadAmmunition()
        {
            if (ReserveAmmunition <= 0) return false;
            if (ReserveAmmunition >= _weaponData.MaxAmunicion)
            {
                Ammunition = _weaponData.MaxAmunicion;
                ReserveAmmunition -= _weaponData.MaxAmunicion;
            }
            else
            {
                Ammunition = ReserveAmmunition;
                ReserveAmmunition = 0;
            }

            return true;
        }
        
        public override bool ReloadReserveAmmunition()
        {
            if (ReserveAmmunition >= _weaponData.MaxReserveAmunicion) return false;

            ReserveAmmunition = _weaponData.MaxReserveAmunicion;

            return true;
        }

        #endregion
        protected override void Shoot()
        {
            var bulletObject = _bulletPooler.GetPooledObject();
            bulletObject.SetActive(true);
            bulletObject.transform.position = _firePoint.position;
            bulletObject.GetComponent<Bullet>()?.Shoot(ShootDirection);
        }
    }
}
