using System;
using System.Collections;
using System.Collections.Generic;
using Game.Managers;
using Game.SO;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class ParticleWeapon : Weapon
    {
        [SerializeField] WeaponSO _weaponData;
        [SerializeField] GameObject _particleBullet;
        [SerializeField] Transform _firePoint;
        [SerializeField] ObjectPooler _bulletPooler;
        [SerializeField] float shootinRateInSeconds = .5f; 
        int _bullets = 0;
        bool _isShooting = false;
        float _time;

        public override int CurrentAmmunition => _bullets;
        void Awake()
        {
            type = Type.PARTICLE;
            _time = shootinRateInSeconds;
            _bullets = _weaponData.MaxBullets;
            _particleBullet.SetActive(false);
        }

        void Update()
        {
            if (_isShooting)
            {
                if (_time <= 0)
                {
                    ShootTriggerBullet();
                    _time = shootinRateInSeconds;
                    _bullets--;
                    GameManager.instance.UpdateBulletCounter(this);
                    if(_bullets <= 0)
                    {
                        StopAttacking();
                    }
                }
                else
                {
                    _time -= Time.deltaTime;
                }
            }
        }

        public override void Attack()
        {
            if (_bullets <= 0) return;
            _particleBullet.SetActive(true);
            _isShooting = true;
        }

        public override void StopAttacking()
        {
            _particleBullet.SetActive(false);
            _isShooting = false;
        }

        public override void ReloadWeapon()
        {
            _bullets = _weaponData.MaxBullets;
        }
        
        void ShootTriggerBullet()
        {
            var bulletObject = _bulletPooler.GetPooledObject();
            bulletObject.SetActive(true);
            bulletObject.transform.position = _firePoint.position;
            bulletObject.GetComponent<Bullet>()?.Shoot(_firePoint.forward);
        }
    }
}
