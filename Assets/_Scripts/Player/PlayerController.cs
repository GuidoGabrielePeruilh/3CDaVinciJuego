using System;
using Game.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] Move _move;
        [SerializeField] Jump _jump;
        [SerializeField, Range(0,10)] private float _speed = 2;
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] float _topClamp = 90.0f;
        [SerializeField] float _bottomClamp = -90.0f;
        [SerializeField] Camera _camera;
        [SerializeField] float _rotationSpeed = 1.0f;
        [SerializeField] bool _invertedYAxis = false;
        [SerializeField] bool _invertedXAxis = false;
        float _targetPitch;
        float _rotationVelocity;
        private Vector2 _lookInput;
        private Vector2 _moveVelocityInput;
        const float _threshold = 0.01f;

        bool IsCurrentDeviceMouse
            => _playerInput.currentControlScheme == "KeyboardMouse";

        void Update()
        {
            _move.Velocity = (_moveVelocityInput.x * transform.right + transform.forward * _moveVelocityInput.y).normalized * _speed;
        }

        void LateUpdate()
        {
            UpdateCameraLook();
            // Physics.Raycast(_camera.transform.forward, );
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveVelocityInput = context.ReadValue<Vector2>();
            if (context.canceled)
            {
                Debug.Log("canceled");
                _moveVelocityInput = Vector2.zero;
            }
        }

       public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _jump.JumpAction();
            }
        }

       public void Look(InputAction.CallbackContext context)
       {
           _lookInput = context.ReadValue<Vector2>();
       }

       void UpdateCameraLook()
       {
           if (_lookInput.sqrMagnitude < _threshold) return;

           float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
           _targetPitch += _lookInput.y * _rotationSpeed * deltaTimeMultiplier * (_invertedYAxis ? 1 : -1);
           _rotationVelocity = _lookInput.x * _rotationSpeed * deltaTimeMultiplier * (_invertedXAxis ? -1 : 1);
           _targetPitch = Utils.ClampAngle(_targetPitch, _bottomClamp, _topClamp);
           _camera.transform.localRotation = Quaternion.Euler(_targetPitch, 0.0f, 0.0f);
           transform.Rotate(Vector3.up * _rotationVelocity);
       }
    }
}