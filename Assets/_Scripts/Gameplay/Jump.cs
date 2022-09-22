using UnityEngine;

namespace Game.Gameplay
{
    public class Jump : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] float _jumpForce = 10f;
        
        public void JumpAction()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
    }
}
