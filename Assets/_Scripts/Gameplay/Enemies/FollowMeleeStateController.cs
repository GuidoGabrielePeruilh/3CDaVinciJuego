using Game.Gameplay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
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

        public RandomPatrolState RandomPatrolState => _randomPatrolState;        
        public FollowState FollowState => _followState;
        public MeleeAttackState MeleeState => _meleeState;
        public FollowPlayer FollowPlayer => _followPlayer;
        public MeleeAttack MeleeAttack => _meleeAttack;
        public int RangeFollow => _rangeFollow;
        public Player Player => _player;
        public Move Move => _move;
        public float RangeMelee => _rangeMelee;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _randomPatrolState = new RandomPatrolState(this, _randomPatrol);
            _followState = new FollowState(this);
            _meleeState = new MeleeAttackState(this);
            _currentState = _randomPatrolState;
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
