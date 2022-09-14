using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class NormalState : State
    {
        VisualField _visualField;
        MonoBehaviour _normalBehaviour;
        State _nextState;
        PatrolFireStateController _controller;

        public NormalState(MonoBehaviour normalBehaviour, VisualField visualField, PatrolFireStateController controller)
        {
            _normalBehaviour = normalBehaviour;
            _visualField = visualField;
            _controller = controller;
        }

        public override void Enter()
        {
            _normalBehaviour.enabled = true;
        }

        public override void Update()
        {
            if (_visualField.IsTargetInView)
                _controller.ChangeState(_controller._attack);
        }

        public override void Exit()
        {
            _normalBehaviour.enabled = false;
        }
    }
}