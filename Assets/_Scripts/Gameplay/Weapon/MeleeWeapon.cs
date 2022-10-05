using System;
using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] GameObject _damaging;
        Action _TriggerAttackAnimation;

        void Awake()
        {
            _damaging.SetActive(false);
        }
        public override void StartAttack(){ }
        public override void PerformedAttack()
        {
            if (!canAttack) return;
            canAttack = false;
            StartMeleeAnimation();
        }
        public override void CancelAttack(){ }

        public override void SubscribeToAnimationEvents(PlayerAnimationManager animationManager)
        {
            animationManager.ADD_ANI_EVENT("start_melee_heatbox", EVENT_START_HITBOX);
            animationManager.ADD_ANI_EVENT("end_melee_heatbox", EVENT_END_HITBOX);
            animationManager.ADD_ANI_EVENT("end_melee_ani", EVENT_FINISH_ANI);
            _TriggerAttackAnimation = animationManager.AttackMelee;
        }

        #region Anim Callbacks

        void EVENT_FINISH_ANI()
        {
            canAttack = true;
        }
    
        void EVENT_END_HITBOX()
        {
            _damaging.SetActive(false);
        }
    
        void EVENT_START_HITBOX()
        {
            _damaging.SetActive(true);
        }
        
        void StartMeleeAnimation()
        {
            _TriggerAttackAnimation.Invoke();
        }
        #endregion
    }   
}