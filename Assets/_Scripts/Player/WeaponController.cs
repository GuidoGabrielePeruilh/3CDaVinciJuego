using Game.Gameplay.Weapon;
using Game.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] WeaponManager manager;

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.started)
                manager.CurrentWeapon.StartAttack();
            if (context.performed)
                manager.CurrentWeapon.PerformedAttack();
            if (context.canceled)
                manager.CurrentWeapon.CancelAttack();
        }

        public void ReloadWeapon(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            var weapon = manager.CurrentWeapon;
            weapon.ReloadAmmunition();
            GameManager.instance.UpdateBulletCounter(weapon.Ammunition);
        }

        public bool ReloadReserveWeapons()
            => manager.ReloadReserveWeapons();

        public void SwitchWeapon(int slot)
            => manager.SwitchWeapon(slot);
    }
}