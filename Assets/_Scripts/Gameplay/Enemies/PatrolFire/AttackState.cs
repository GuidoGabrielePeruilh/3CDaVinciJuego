using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class AttackState : State
    {
        MonoBehaviour _attackBehaviour;
        VisualField _visualField;
        PatrolFireStateController _controller;
        Move _move;
        ActionRepeater _shooterRepeater;
        LookAtTarget _lookAtTarget;
        ThrowBullet _throwBullet;

        public AttackState(PatrolFireStateController controller)
        {
            _controller = controller;
            _attackBehaviour = controller.AttackBehaviour;
            _visualField = controller.VisualField;
            _move = controller.Move;
            _shooterRepeater = controller.ShooterRepeater;
            _lookAtTarget = controller.LookAtTarget;
            _throwBullet = controller.ThrowBullet;
        }

        public override void Enter()
        {
            _move.Velocity = Vector3.zero;
            _attackBehaviour.enabled = true;
            _lookAtTarget.enabled = true;
            _shooterRepeater.enabled = true;
        }
        
        public override void Update()
        {
            if (!_visualField.IsTargetInView)
                _controller.ChangeState(_controller.Normal);
        }

        public override void Exit()
        {
            _attackBehaviour.enabled = false;
            _shooterRepeater.enabled = false;
            _lookAtTarget.enabled = false;
        }
    }
}