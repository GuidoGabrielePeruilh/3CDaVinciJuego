using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface StateController
    {
        public void ChangeState(State nextState);
    }
    public class PatrolFireStateController : MonoBehaviour, StateController
    {
        public State _normal;
        public State _attack;

        [SerializeField] MonoBehaviour _normalBehavoiur;
        [SerializeField] MonoBehaviour _attackBehavoiur;

        State _currentState;

        void Awake()
        {
            _normal = new Normal(_normalBehavoiur);
            _attack = new Normal(_attackBehavoiur);
        }
        
        void Start()
        {
            _currentState.Enter();
        }

        void Update()
        {
            _currentState.Update();
        }

        public void ChangeState(State nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }
    }

    public abstract class State<T>
    {
        protected T context;

        public State(T context)
        {
            context = context;
        }
        public virtual void Enter()
        {
            
        }
        public virtual void Update()
        {
        }
        public virtual void Exit()
        {
            
        }
    }

    public class Normal : State<>
    {
        public Normal(MonoBehaviour behaviour) : base(behaviour)
        {
        }

        public override void Update()
        {
            if (Vector3.Distance(_target.transform.position, transform.position) > _visualDistance) return false;
            var direction = _target.transform.position - transform.position;
            if (Vector3.Angle(direction, transform.forward) > _visualAngle) return false;

            return true;
            base.Update();
        }
    }

    public class Attack : State
    {
        public Attack(MonoBehaviour behaviour) : base(behaviour)
        {
        }

        

    } 
}
