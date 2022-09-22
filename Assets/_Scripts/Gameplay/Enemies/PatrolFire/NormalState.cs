using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class NormalState : State
    {
        VisualField _visualField;
        MonoBehaviour _normalBehaviour;
        PatrolFireStateController _controller;

        public NormalState(PatrolFireStateController controller)
        {
            _normalBehaviour = controller.NormalBehaviour;
            _visualField = controller.VisualField;
            _controller = controller;
        }

        public override void Enter()
        {
            _normalBehaviour.enabled = true;
        }

        public override void Update()
        {
            if (_visualField.IsTargetInView)
                _controller.ChangeState(_controller.Attack);
        }

        public override void Exit()
        {
            _normalBehaviour.enabled = false;
        }
    }
}