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

        public NormalState(FlyerPatrolStateController stateController, PatrolBehaviour patrolBehaviour, GameObject target)
        {
            _stateController = stateController;
            _patrolBehaviour = patrolBehaviour;
            _target = target;
        }
        public override void Enter()
        {
            _patrolBehaviour.enabled = true;
            Debug.Log("entre");
        }
        public override void Update()
        {
            if (Vector3.Distance(_target.transform.position, _stateController.transform.position) <= 20)
            {
                ChangeToAttack();
            }
        }
        public override void Exit()
        {
            _patrolBehaviour.enabled = false;
            Debug.Log("sali");
        }     
        void ChangeToAttack()
        {
            _stateController.ChangeState(NextState);
        }      
    }
}
