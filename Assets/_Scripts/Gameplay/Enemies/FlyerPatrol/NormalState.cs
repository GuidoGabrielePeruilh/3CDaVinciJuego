using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies.FlyerPatrol
{
    public class NormalState : State
    {        
        FlyerPatrolStateController _stateController;
        PatrolBehaviour _patrolBehaviour;
        GameObject _target;
        Vector3 _velocityCheckpoint = Vector3.zero;
        Move _move;
        float _maxDistance = 20;
        LookAtTarget _lookAtTarget;

        public NormalState(FlyerPatrolStateController stateController, PatrolBehaviour patrolBehaviour, GameObject target, Move move, float maxDistance, LookAtTarget lookAtTarget)
        {
            _stateController = stateController;
            _patrolBehaviour = patrolBehaviour;
            _target = target;
            _move = move;
            _maxDistance = maxDistance;
            _lookAtTarget = lookAtTarget;
        }
        public override void Enter()
        {
            _lookAtTarget.transform.forward = Vector3.down;
            _patrolBehaviour.enabled = true;
            if (_velocityCheckpoint != Vector3.zero)
            {
                _move.Velocity = _velocityCheckpoint;
            }
        }
        public override void Update()
        {
            if (Vector3.Distance(_target.transform.position, _stateController.transform.position) <= _maxDistance)
            {
                ChangeToAttack();
            }
        }
        public override void Exit()
        {
            _patrolBehaviour.enabled = false;
            _velocityCheckpoint = _move.Velocity;
        }     
        void ChangeToAttack()
        {
            _stateController.ChangeState(NextState);
        }      
    }
}
