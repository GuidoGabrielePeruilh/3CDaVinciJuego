﻿using Game.Gameplay.Enemies;
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
            var _distanceFromPlayer = Vector3.Distance(_stateController.transform.position, _stateController.Player.transform.position);
            if (_distanceFromPlayer > _stateController.RangeFollow)
            {
                _stateController.SwitchState(_stateController.RandomPatrolState);
            }
            if( _distanceFromPlayer < _stateController.RangeMelee)
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
