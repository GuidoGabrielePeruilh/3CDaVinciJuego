using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackState : State
    {

        private MeleeAttack _meleeAttack;
        private Move _move;


        public MeleeAttackState(FollowMeleeStateController stateController)
        {
            _meleeAttack = stateController.MeleeAttack;
            _move = stateController.Move;
        }
        public override void Enter()
        {
            _move.Velocity = Vector3.zero;
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
