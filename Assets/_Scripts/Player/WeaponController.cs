using Game.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] WeaponManager manager;
        [SerializeField] PointerTarget _pointerTarget;

        public void Attack(InputAction.CallbackContext context)
        {
            var currentWeapon = manager.CurrentWeapon;
            currentWeapon.Target = _pointerTarget.transform.position;
            if (context.started)
                currentWeapon.StartAttack();
            if (context.performed)
                currentWeapon.PerformedAttack();
            if (context.canceled)
                currentWeapon.CancelAttack();
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