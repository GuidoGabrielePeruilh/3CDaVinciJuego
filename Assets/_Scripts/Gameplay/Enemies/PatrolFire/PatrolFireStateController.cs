using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class PatrolFireStateController : MonoBehaviour
    {
        public NormalState _normal;
        public AttackState _attack;

        [SerializeField] MonoBehaviour _normalBehaviour;
        [SerializeField] VisualField _visualField;
        [SerializeField] MonoBehaviour _attackBehaviour;  
        [SerializeField] Move _move;

        State _currentState;

        void Awake()
        {
            _normal = new NormalState(_normalBehaviour, _visualField, this);
            _attack = new AttackState(_attackBehaviour, _visualField, _move, this);
            _currentState = _normal;
            _attackBehaviour.enabled = false;
            _normalBehaviour.enabled = true;
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

        public AttackState Attack => _attack;
        public NormalState Normal => _normal;
        public MonoBehaviour NormalBehaviour => _normalBehaviour;
        public VisualField VisualField => _visualField;
    }
}