using Game.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    [RequireComponent(typeof(InputController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 2f;
        [SerializeField] float _rotationSpeed = 0f;


        InputController _inputController = null;

        private void Awake()
        {
            _inputController = GetComponent<InputController>();
        }
        private void Update()
        {
            Move();
        }
        void Move()
        {
            Vector2 input = _inputController.MoveInput();

            transform.position += transform.forward * input.y * speed * Time.deltaTime; 
        }

        /*
        [SerializeField] InputAction _moveInput = null;
        [SerializeField] InputAction _cameraInput = null;
        Rigidbody _myRg;
        
        private void Start()
        {
            _myRg = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            _moveInput.Enable();
            _cameraInput.Enable();
        }
        private void OnDisable()
        {
            _moveInput.Disable();
            _cameraInput.Disable();
        }
        public Vector2 MoveInput()
        {
            return _moveInput.ReadValue<Vector2>();
        }
        public Vector2 CameraInput()
        {
            return _cameraInput.ReadValue<Vector2>();    
        }
        private void FixedUpdate()
        {
            _myRg.velocity = transform.position * speed * Time.fixedDeltaTime;
        }
        
        [SerializeField] PlayerInput playerInput;
        Vector3 input;
        void OnAttack(InputValue valor)
        {
            print("ataque");
        }
        void OnMovimiento(InputValue valor)
        {
            Vector2 inputMovement = valor.Get<Vector2>();
            input = new Vector3(inputMovement.x, 0, inputMovement.y);
        }
        */
    }
}