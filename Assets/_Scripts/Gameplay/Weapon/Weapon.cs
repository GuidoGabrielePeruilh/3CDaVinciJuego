using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] 
        protected float attackRateInSeconds = 0f;
        protected bool canAttack = true;

        public int Ammunition { get; protected set; } = -1;
        public int ReserveAmmunition { get; protected set; } = -1;
        public Vector3 Target { set; protected get; } = Vector3.zero;
        public virtual bool ReloadAmmunition() => false;
        public virtual bool ReloadReserveAmmunition() => false;
        public abstract void StartAttack();
        public abstract void PerformedAttack();
        public abstract void CancelAttack();
        public virtual void SubscribeToAnimationEvents(PlayerAnimationManager playerAnimationManager) {}
    }
}