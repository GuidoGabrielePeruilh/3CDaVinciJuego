using Game.Gameplay.Enemies;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class RandomPatrolState : State
    {
        private RandomPatrol _randomPatrol;   
        private FollowMeleeStateController _stateController;

        public RandomPatrolState(FollowMeleeStateController followMeleeStateController, RandomPatrol randomPatrol)
        {
            _stateController = followMeleeStateController;
            _randomPatrol = randomPatrol;
        }

        public override void Enter()
        {
            _randomPatrol.enabled = true;
        }
        public override void Update()
        {
            var _distanceFromPlayer = Vector3.Distance(_stateController.transform.position, _stateController.Player.transform.position);
            if (_distanceFromPlayer <= _stateController.RangeFollow)
            {
                _stateController.SwitchState(_stateController.FollowState);
            }
        }
        public override void Exit()
        {
            _randomPatrol.enabled = false;
        }
    }
}
