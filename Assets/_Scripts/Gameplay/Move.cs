using UnityEngine;

namespace Game.Gameplay
{
    public class Move : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        [Space]
        [Tooltip("Si ignora el eje del Velocity, tomara el eje del rigidbody")]
        [SerializeField] bool _ignoreX = false;
        [SerializeField] bool _ignoreY = false;
        [SerializeField] bool _ignoreZ = false;

        void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(
                _ignoreX? _rigidbody.velocity.x : Velocity.x,
                _ignoreY? _rigidbody.velocity.y : Velocity.y,
                _ignoreZ? _rigidbody.velocity.z : Velocity.z
                );
        }
        
        [field: SerializeField]
        public Vector3 Velocity { get; set; } = Vector3.zero;
    }
}
