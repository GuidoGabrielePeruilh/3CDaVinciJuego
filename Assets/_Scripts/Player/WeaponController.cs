using Game.Gameplay.Weapon;
using UnityEngine;

namespace Game.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] WeaponInventory _inventory;

        public void ShootWeapon()
        {
            _inventory.CurrentWeapon.GetComponent<Weapon>()?.ShootBullet();
        }

        public void ReloadWeapon()
        {
            _inventory.CurrentWeapon.GetComponent<Weapon>()?.ReloadWeapon();
        }
    }
}