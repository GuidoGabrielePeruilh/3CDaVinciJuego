using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class RandomPatrolState : State
    {
        RandomPatrol _randomPatrol;   
        FollowMeleeStateController _stateController;

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
            Vector3 position = _stateController.transform.position;
            Vector3 playerPosition = _stateController.Player.transform.position;           
            var _distanceFromPlayer = Vector3.Distance(position, playerPosition);
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
