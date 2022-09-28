using UnityEngine;

namespace Game.Gameplay
{
    public class Jump : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] float _jumpForce = 10f;
        [SerializeField] LayerMask _floorLayer;
        [SerializeField] GameObject _cheeckFloor;
        [SerializeField, Range(0, 2)] float _floorRadius;
        bool _canJump = true;
        void Update()
        {
            OnTheFloor();
        }
        public void JumpAction()
        {
            if (_canJump)
            {
                _canJump = false;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            }            
        }
        public void OnTheFloor()
        {
            if (Physics.OverlapSphere(_cheeckFloor.transform.position, _floorRadius, _floorLayer).Length >= 1)
            {
                _canJump = true;
            }
            else if (Physics.OverlapSphere(_cheeckFloor.transform.position, _floorRadius, _floorLayer).Length <= 1)
            {
                _canJump = false;
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_cheeckFloor.transform.position, _floorRadius);
        }
    }
}
