using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] GameObject _damaging;
        bool _canAttack = true;
    
        void Awake()
        {
            type = Type.MELEE;
            _damaging.SetActive(false);
        }
        
        public override bool CanAttack() => _canAttack;

        public override void Attack()
        {
            _canAttack = false;
        }

        public override void SubscribeToAnimationEvents(PlayerAnimationManager animationManager)
        {
            animationManager.ADD_ANI_EVENT("start_melee_heatbox", EVENT_START_HITBOX);
            animationManager.ADD_ANI_EVENT("end_melee_heatbox", EVENT_END_HITBOX);
            animationManager.ADD_ANI_EVENT("end_melee_ani", EVENT_FINISH_ANI);
        }

        #region Anim Callbacks

        void EVENT_FINISH_ANI()
        {
            _canAttack = true;
        }
    
        void EVENT_END_HITBOX()
        {
            _damaging.SetActive(false);
        }
    
        void EVENT_START_HITBOX()
        {
            _damaging.SetActive(true);
        }
        #endregion
    }   
}