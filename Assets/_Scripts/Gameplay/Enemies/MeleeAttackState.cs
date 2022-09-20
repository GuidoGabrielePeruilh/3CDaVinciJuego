using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay
{
    public class MeleeAttackState : State
    {
        FollowMeleeStateController _stateController;
        private MeleeAttack _meleeAttack;
        private Move _move;


        public MeleeAttackState(FollowMeleeStateController stateController)
        {
            _stateController = stateController;
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
            var _distanceFromPlayer = Vector3.Distance(_stateController.transform.position, _stateController.Player.transform.position);
            if (_distanceFromPlayer > _stateController.RangeFollow)
            {
                _stateController.SwitchState(_stateController.RandomPatrolState);
            }
            else if (_distanceFromPlayer < _stateController.RangeFollow && _distanceFromPlayer > _stateController.RangeMelee)
            {
                _stateController.SwitchState(_stateController.FollowState);
            }
        }
        public override void Exit()
        {
            _meleeAttack.enabled = false;
        }
    }
}
