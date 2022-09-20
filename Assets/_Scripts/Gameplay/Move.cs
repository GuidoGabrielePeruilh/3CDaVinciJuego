using UnityEngine;

namespace Game
{
    public class Move : MonoBehaviour
    {
        [field : SerializeField] public Vector3 Velocity { get; set; } = Vector3.zero;

        [SerializeField] Rigidbody _myRg;

        [SerializeField] bool _ignoreX = false;
        [SerializeField] bool _ignoreY = false;
        [SerializeField] bool _ignoreZ = false;

        private void FixedUpdate()
        {
            _myRg.velocity = new Vector3(
                 _ignoreX ? _myRg.velocity.x : Velocity.x,
                 _ignoreY ? _myRg.velocity.y : Velocity.y,
                 _ignoreZ ? _myRg.velocity.z : Velocity.z
                );
            transform.forward = _myRg.velocity;
        }

    }
}
