using System.Collections.Generic;
using Game.Gameplay.Weapon;
using UnityEngine;

namespace Game.Player
{
    public class WeaponInventory : MonoBehaviour
    {
        [field: SerializeField]
        public List<Weapon> Weapons { get; private set; }
        void Awake()
        {
            foreach (var weapon in Weapons)
            {
                weapon.gameObject.SetActive(false);
            }
        }

        public Weapon GetWeapon(int slot)
        {
            if (slot < 0 || slot >= Weapons.Count) return null;
            return Weapons[slot];
        }
    }
}