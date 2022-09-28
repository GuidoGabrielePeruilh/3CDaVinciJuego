using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public enum Type { MELEE, SHOOTER, PARTICLE}
        public Type type;
        public virtual bool CanAttack() => true;
        
        public abstract void ShootBullet();
        public virtual void StopShooting() {}
        public abstract void ReloadWeapon();
    }
}