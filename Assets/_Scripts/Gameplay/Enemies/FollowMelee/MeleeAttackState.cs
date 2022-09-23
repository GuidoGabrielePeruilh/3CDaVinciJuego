using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class MeleeAttackState : State
    {
        FollowMeleeStateController _stateController;
        MeleeAttack _meleeAttack;
        Move _move;
        LookAtTarget _lookAtTarget;

        public MeleeAttackState(FollowMeleeStateController stateController)
        {
            _stateController = stateController;
            _meleeAttack = stateController.MeleeAttack;
            _move = stateController.Move;
            _lookAtTarget = stateController.LookAtTarget;
        }
        public override void Enter()
        {
            _move.Velocity = Vector3.zero;
            _meleeAttack.enabled = true;
            _lookAtTarget.enabled = true;

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
            _lookAtTarget.enabled = false;
        }
    }
}
