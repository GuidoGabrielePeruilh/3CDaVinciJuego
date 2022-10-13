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
        [Tooltip("Max distance from player to change between States")]
        [SerializeField] float _maxDistance;

        void Awake()
        {
            _target = FindPlayer();
            _lookAtTarget.Target = _target;
            _visualField.Target = _target;
            _normalState = new NormalState(this, _patrolBehaviour, _target, _move, _maxDistance, _lookAtTarget);
            _attackState = new AttackState(this, _lookAtTarget, _attack,_move, _target, _maxDistance);
            _normalState.NextState = _attackState;
            _attackState.NextState = _normalState;
            _attack.enabled = _lookAtTarget.enabled = false;
            FirstState();
        }
        
        void Update()
        {
            UpdateState();
        }
        public void ChangeState(State state)
        {
            Debug.Log("change to ->" + state.ToString());
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
