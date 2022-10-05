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
            _meleeAttack.Attack();
        }
        public override void Update()
        {
            if (_stateController.IsAttacking) return;
            Vector3 position = _stateController.transform.position;
            Vector3 playerPosition = _stateController.Player.transform.position;
            if (!Utils.IsInRangeOfVision(position, playerPosition, _stateController.RangeMelee, _stateController.RangeOfVisionY))
            {
                _stateController.SwitchState(_stateController.FollowState);
            }
            else
            {
                _meleeAttack.Attack();
            }
        }
        public override void Exit()
        {
            _meleeAttack.enabled = false;
            _lookAtTarget.enabled = false;
        }
    }
}
