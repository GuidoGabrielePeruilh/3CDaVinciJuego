using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void ShootBullet();
        public abstract void ReloadWeapon();
    }
}