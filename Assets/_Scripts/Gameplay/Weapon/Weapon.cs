using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public enum Type { MELEE, SHOOTER, PARTICLE}
        public Type type;
        public virtual bool CanAttack() => true;
        
        public abstract void Attack();
        public virtual void StopAttacking() {}
        public virtual void ReloadWeapon() {}
        public virtual void SubscribeToAnimationEvents(PlayerAnimationManager playerAnimationManager) {}
    }
}