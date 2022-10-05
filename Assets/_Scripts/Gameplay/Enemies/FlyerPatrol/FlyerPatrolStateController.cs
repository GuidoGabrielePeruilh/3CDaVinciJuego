using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies.FlyerPatrol
{
    public class FlyerPatrolStateController : MonoBehaviour
    {
        State _currentState;
        NormalState _normalState;
        AttackState _attackState;
        GameObject _target;
        [SerializeField] RaycastAttack _attack;
        [SerializeField] PatrolBehaviour _patrolBehaviour;
        [SerializeField] LookAtTarget _lookAtTarget;
        [SerializeField] Move _move;
        [SerializeField] VisualField _visualField;
        

        void Awake()
        {
            _target = FindPlayer();
            _lookAtTarget.Target = _target;
            _visualField.Target = _target;
            _normalState = new NormalState(this, _patrolBehaviour, _target);
            _attackState = new AttackState(this, _lookAtTarget, _attack,_move, _target);
            _normalState.NextState = _attackState;
            _attackState.NextState = _normalState;
            FirstState();
        }
        
        void Update()
        {
            UpdateState();
        }
        public void ChangeState(State state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        void FirstState()
        {
            _currentState = _normalState;
            _currentState.Enter();
        }
        void UpdateState()
        {
            _currentState.Update();
        }
        GameObject FindPlayer()
        {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }

    

    
}
