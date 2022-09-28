using Game.Gameplay.Weapon;
using UnityEngine;

namespace Game.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] WeaponInventory _inventory;
        [SerializeField] AniController _ani;

        public void ShootWeapon()
        {

            var weapon = _inventory.CurrentWeapon.GetComponent<Weapon>();
            if(!weapon.CanAttack()) return;
            switch (weapon.type)
            {
                case Weapon.Type.MELEE:
                    _ani.AttackMelee();
                    break;
                case Weapon.Type.SHOOTER:
                    break;
                case Weapon.Type.PARTICLE:
                    break;
                default:
                    break;
            }
            //weapon?.ShootBullet();

        }
        
        public void StopShootingWeapon()
        {
            _inventory.CurrentWeapon.GetComponent<Weapon>()?.StopShooting();
        }

        public void ReloadWeapon()
        {
            _inventory.CurrentWeapon.GetComponent<Weapon>()?.ReloadWeapon();
        }
    }
}