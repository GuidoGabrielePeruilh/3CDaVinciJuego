using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackState : State
    {

        private MeleeAttack _meleeAttack;
        private FollowMeleeStateController _stateController;
        public override void Enter()
        {
            _meleeAttack.enabled = true;
        }
        public override void Update()
        {
            
        }
        public override void Exit()
        {
            _meleeAttack.enabled = false;
        }
    }
}
