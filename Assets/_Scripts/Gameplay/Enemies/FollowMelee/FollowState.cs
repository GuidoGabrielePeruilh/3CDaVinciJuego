using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class FollowState : State
    {
        FollowMeleeStateController _stateController;
        FollowPlayer _followPlayer;
        LookAtTarget _lookAtTarget;

        public FollowState(FollowMeleeStateController stateController)
        {
            _stateController = stateController;
            _followPlayer = stateController.FollowPlayer;
            _lookAtTarget = stateController.LookAtTarget;
            
        }
        public override void Enter()
        {
            _followPlayer.enabled = true;
            _lookAtTarget.enabled = true;
            
        }
        public override void Update()
        {
            Vector3 position = _stateController.transform.position;
            Vector3 playerPosition = _stateController.Player.transform.position;
            if (!Utils.IsInRangeOfVision(position, playerPosition, _stateController.RangeFollow, _stateController.RangeOfVisionY))
            {
                _stateController.SwitchState(_stateController.RandomPatrolState);
            }
            else if(Utils.IsInRangeOfVision(position, playerPosition, _stateController.RangeMelee, _stateController.RangeOfVisionY))
            {
                _stateController.SwitchState(_stateController.MeleeState);
            }
        }
        public override void Exit()
        {
            _followPlayer.enabled = false;
            _lookAtTarget.enabled = false;
        }
    }
}
