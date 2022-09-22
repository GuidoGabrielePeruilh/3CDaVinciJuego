using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class PatrolFireStateController : MonoBehaviour
    {
        [SerializeField] MonoBehaviour _normalBehaviour;
        [SerializeField] VisualField _visualField;
        [SerializeField] MonoBehaviour _attackBehaviour;  
        [SerializeField] Move _move;
        [SerializeField] ActionRepeater _shooterRepeater;
        [SerializeField] LookAtTarget _lookAtTarget;
        [SerializeField] ThrowBullet _throwBullet;

        NormalState _normal;
        AttackState _attack;
        State _currentState;
        GameObject _player;

        void Awake()
        {
            _player = FindObjectOfType<PlayerController>()?.gameObject;
            _throwBullet.Target = _lookAtTarget.Target = _visualField.Target = _player;
            
            _normal = new NormalState(this);
            _attack = new AttackState(this);
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
        public MonoBehaviour AttackBehaviour => _attackBehaviour;
        public Move Move => _move;
        public ActionRepeater ShooterRepeater => _shooterRepeater;
        public LookAtTarget LookAtTarget => _lookAtTarget;
        public ThrowBullet ThrowBullet => _throwBullet;
        public GameObject Target => _player;
    }
}