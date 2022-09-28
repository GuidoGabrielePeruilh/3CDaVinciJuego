using Game.Gameplay.Weapon;
using UnityEngine;

namespace Game.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] WeaponManager manager;
        [SerializeField] PlayerAnimationManager _animationManager;

        public void ShootWeapon()
        {
            var weapon = manager.CurrentWeapon.GetComponent<Weapon>();
            if(!weapon.CanAttack()) return;
            switch (weapon.type)
            {
                case Weapon.Type.MELEE:
                    _animationManager.AttackMelee();
                    break;
                case Weapon.Type.SHOOTER:
                    _animationManager.AttackShooter();
                    break;
                case Weapon.Type.PARTICLE:
                    weapon.Attack();
                    break;
                default:
                    break;
            }
        }
        
        public void StopShootingWeapon()
        {
            manager.CurrentWeapon.GetComponent<Weapon>()?.StopAttacking();
        }

        public void ReloadWeapon()
        {
            manager.CurrentWeapon.GetComponent<Weapon>()?.ReloadWeapon();
        }
    }
}