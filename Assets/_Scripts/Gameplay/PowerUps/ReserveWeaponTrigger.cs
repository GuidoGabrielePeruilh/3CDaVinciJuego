using Game.Player;
using UnityEngine;

namespace Game.Gameplay.PowerUps
{
    public class ReserveWeaponTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            var weaponController = other.GetComponent<WeaponController>();
            if (weaponController == null) return;
            if (!weaponController.ReloadReserveWeapons()) return;

            Destroy(gameObject);
        }
    }
}
