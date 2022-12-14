using System;
using Game.Player;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class FollowMeleeStateController : MonoBehaviour
    {
        [SerializeField] RandomPatrol _randomPatrol;
        [SerializeField, Range(0, 15)] int _rangeFollow = 15;
        [SerializeField, Range(.1f, 3f)] float _rangeOfVisionY = 1;
        [SerializeField] FollowPlayer _followPlayer;
        [SerializeField] MeleeAttack _meleeAttack;
        [SerializeField] Move _move;
        [SerializeField] LookAtTarget _lookAtTarget;
        [SerializeField, Range(0f, 5f)] float _moveSpeed = 5f;
        [SerializeField] EventAnimation _eventAnimation;
        [SerializeField] EnemyDamageable _enemyDamagable;
        State _currentState;
        PlayerController _player;
        RandomPatrolState _randomPatrolState;
        FollowState _followState;
        MeleeAttackState _meleeState;
        float _rangeMelee = 0.5f;
        bool _isAttacking;

        public RandomPatrolState RandomPatrolState => _randomPatrolState;
        public FollowState FollowState => _followState;
        public MeleeAttackState MeleeState => _meleeState;
        public FollowPlayer FollowPlayer => _followPlayer;
        public MeleeAttack MeleeAttack => _meleeAttack;
        public int RangeFollow => _rangeFollow;
        public LookAtTarget LookAtTarget => _lookAtTarget;
        public PlayerController Player => _player;
        public Move Move => _move;
        public float RangeMelee => _rangeMelee;
        public float RangeOfVisionY => _rangeOfVisionY;
        public bool IsAttacking
        {
            get => _isAttacking;
            private set { _isAttacking = value; }
        }

        void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _lookAtTarget.Target = _player.gameObject;
            _rangeMelee = _followPlayer.CloseRange;
            _randomPatrol.Speed = _followPlayer.Speed = _moveSpeed;
            _followPlayer.RangeOfVisionY = _rangeOfVisionY;
            _randomPatrolState = new RandomPatrolState(this, _randomPatrol);
            _followState = new FollowState(this);
            _meleeState = new MeleeAttackState(this);
            _randomPatrol.enabled = false;
            _followPlayer.enabled = false;
            _meleeAttack.enabled = false;
            _currentState = _randomPatrolState;
        }

        void OnEnable()
        {
            _eventAnimation.OnAttackStarts += () => IsAttacking = true;
            _eventAnimation.OnAttackEnds += () => IsAttacking = false;
        }

        void OnDisable()
        {
            _eventAnimation.OnAttackStarts -= () => IsAttacking = true;
            _eventAnimation.OnAttackEnds -= () => IsAttacking = false;
        }

        void Start()
        {
            _currentState.Enter();
        }
        void Update()
        {
            if (_enemyDamagable.Life > 0)
            {
                _currentState.Update();
            }
            else
            {
                _lookAtTarget.enabled = false;
                _followPlayer.enabled = false;
                _move.Velocity = Vector3.zero;
            }


        }
        public void SwitchState(State state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

}
