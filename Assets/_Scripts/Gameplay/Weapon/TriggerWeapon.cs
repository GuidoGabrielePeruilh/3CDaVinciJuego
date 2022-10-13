using System;
using System.Collections;
using Game.Player;
using Game.Managers;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class TriggerWeapon : ShooterWeapon
    {
        Action _TriggerAttackAnimation;
        WaitForSeconds _waitAttackRate;
        void Awake()
        {
            _waitAttackRate = new WaitForSeconds(attackRateInSeconds);
            Ammunition = _weaponData.MaxAmunicion;
            ReserveAmmunition = _weaponData.MaxReserveAmunicion;
        }

        #region public
        public override void StartAttack(){ }
        public override void PerformedAttack()
        {
            if (!canAttack || Ammunition <= 0) return;
            canAttack = false;
            _TriggerAttackAnimation.Invoke();
            StartCoroutine(CO_AttackRate());
        }

        IEnumerator CO_AttackRate()
        {
            yield return _waitAttackRate;
            canAttack = true;
        }

        public override void CancelAttack(){ }

        public override void SubscribeToAnimationEvents(PlayerAnimationManager animationManager)
        {
            animationManager.ADD_ANI_EVENT("pistol_shooting_event", EVENT_PISTOL_SHOOTING);
            _TriggerAttackAnimation = animationManager.AttackShooter;
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
            bulletObject.transform.position = _firePoint.position;
            bulletObject.SetActive(true);
            bulletObject.GetComponent<Bullet>()?.Shoot(ShootDirection);
            Ammunition--;
            GameManager.instance.UpdateBulletCounter(Ammunition);
        }

        void EVENT_PISTOL_SHOOTING()
        {
            Shoot();
        }
    }
}