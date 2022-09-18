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
        MeleeState _meleeState;
        [SerializeField] RandomPatrol _randomPatrol;
        [SerializeField] int _rangeFollow = 100;
        [SerializeField] float _rangeMelee = 0.5f;
        [SerializeField] FollowPlayer _followPlayer;

        public RandomPatrolState RandomPatrolState => _randomPatrolState;        
        public FollowState FollowState => _followState;
        public MeleeState MeleeState => _meleeState;
        public int RangeFollow => _rangeFollow;
        public Player Player => _player;
        public float RangeMelee => _rangeMelee;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _randomPatrolState = new RandomPatrolState(this, _randomPatrol);
            _followState = new FollowState(this, _followPlayer );
            _meleeState = new MeleeState();
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
    public class MeleeState : State
    {
        public override void Enter()
        {
            Debug.Log("enter");
        }
        public override void Update()
        {
            Debug.Log("update");
        }
        public override void Exit()
        {
            Debug.Log("exit");
        }
    }
}
