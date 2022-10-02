using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public enum Type { MELEE, SHOOTER, PARTICLE}
        public Type type;
        public virtual int CurrentAmmunition => 0;
        public virtual bool CanAttack() => true;
        
        public abstract void Attack();
        public virtual void StopAttacking() {}
        public virtual bool ReloadWeapon() => false;
        public virtual bool ReloadReserve() => false;
        public virtual void SubscribeToAnimationEvents(PlayerAnimationManager playerAnimationManager) {}
    }
}