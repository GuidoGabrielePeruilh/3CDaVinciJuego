using Game.Gameplay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class FollowMeleeStateController : MonoBehaviour
    {
        State _currentState;
        private Player _player;
        RandomPatrolState _randomPatrolState;
        FollowState _followState;
        MeleeAttackState _meleeState;
        [SerializeField] RandomPatrol _randomPatrol;
        [SerializeField, Range(0, 10)] int _rangeFollow = 9;
        float _rangeMelee = 0.5f;
        [SerializeField] FollowPlayer _followPlayer;
        [SerializeField] MeleeAttack _meleeAttack;
        [SerializeField] Move _move;
        [SerializeField] LookAtTarget _lookAtTarget;
        [SerializeField, Range(0f, 5f)] private float _moveSpeed = 5f;
        
        public RandomPatrolState RandomPatrolState => _randomPatrolState;        
        public FollowState FollowState => _followState;
        public MeleeAttackState MeleeState => _meleeState;
        public FollowPlayer FollowPlayer => _followPlayer;
        public MeleeAttack MeleeAttack => _meleeAttack;
        public int RangeFollow => _rangeFollow;
        public LookAtTarget LookAtTarget => _lookAtTarget;
        public Player Player => _player;
        public Move Move => _move;
        public float RangeMelee => _rangeMelee;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _lookAtTarget.Target = _player.gameObject;
            _rangeMelee = _followPlayer.CloseRange;
            _randomPatrol.Speed = _followPlayer.Speed = _moveSpeed;
            _randomPatrolState = new RandomPatrolState(this, _randomPatrol);
            _followState = new FollowState(this);
            _meleeState = new MeleeAttackState(this);
            _randomPatrol.enabled = false;
            _followPlayer.enabled = false;
            _meleeAttack.enabled = false;
            _currentState = _randomPatrolState;
            
        }
        private void Start()
        {
            _currentState.Enter();
        }
        private void Update()
        {
            _currentState.Update();
        }
        public void SwitchState(State state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
  
}
