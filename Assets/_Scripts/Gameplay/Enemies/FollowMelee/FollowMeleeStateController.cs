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
        [SerializeField] int _rangeFollow = 100;
        [SerializeField] float _rangeMelee = 0.5f;
        [SerializeField] FollowPlayer _followPlayer;
        [SerializeField] MeleeAttack _meleeAttack;
        [SerializeField] Move _move;
        [SerializeField] LookAtTarget _lookAtTarget;

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
