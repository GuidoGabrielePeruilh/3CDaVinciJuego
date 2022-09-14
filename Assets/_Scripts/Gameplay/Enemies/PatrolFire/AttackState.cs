using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class AttackState : State
    {
        MonoBehaviour _attackBehaviour;
        VisualField _visualField;
        PatrolFireStateController _controller;
        Move _move;

        public AttackState(MonoBehaviour attackBehaviour, VisualField visualField, Move move, PatrolFireStateController controller)
        {
            _attackBehaviour = attackBehaviour;
            _visualField = visualField;
            _controller = controller;
            _move = move;
        }

        public override void Enter()
        {
            Debug.Log("Entro a Attack");
            _move.Velocity = Vector3.zero;
            _attackBehaviour.enabled = true;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Update()
        {
            if (!_visualField.IsTargetInView)
                _controller.ChangeState(_controller.Normal);
        }

        public override void Exit()
        {
            Debug.Log("Salio a Attack");
            _attackBehaviour.enabled = false;
        }
    }
}