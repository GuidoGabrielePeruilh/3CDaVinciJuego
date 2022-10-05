using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies.FlyerPatrol
{
    public class AttackState : State
    {

        FlyerPatrolStateController _stateController;
        LookAtTarget _lookAtTarget;
        RaycastAttack _attack;
        Move _move;
        GameObject _target;

        public AttackState(FlyerPatrolStateController stateController, LookAtTarget lookAtTarget, RaycastAttack attack, Move move, GameObject target)
        {
            _stateController = stateController;
            _lookAtTarget = lookAtTarget;
            _attack = attack;
            _move = move;
            _target = target;
        }

        public override void Enter()
        {
            _attack.enabled = true;
            _lookAtTarget.enabled = true;
        }
        public override void Update()
        {
            if (Vector3.Distance(_target.transform.position, _stateController.transform.position) > 20)
            {
                ChangeToNormal();
            }
        }
        public override void Exit()
        {
            _attack.enabled = false;
            _lookAtTarget.enabled = false;
        }
             
        void ChangeToNormal()
        {
            _stateController.ChangeState(NextState);
        }
        void StopMove()
        {
            _move.Velocity = Vector3.zero;
        }       
    }
}
