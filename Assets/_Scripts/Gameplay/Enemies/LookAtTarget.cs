using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField, Range(0f, 10f)] float _speedRotation = 10f;
        [SerializeField] bool _ignoreX, _ignoreY, _ignoreZ = false;
        void Update()
        {
            var targetDirection = _target.transform.position - transform.position;
            targetDirection = new Vector3(
                _ignoreX ? 0 : targetDirection.x,
                _ignoreY ? 0 : targetDirection.y,
                _ignoreZ ? 0 : targetDirection.z
                );
            transform.forward = Vector3.Slerp(transform.forward, targetDirection,Time.deltaTime * _speedRotation);
        }

        public GameObject Target
        {
            get => _target;
            set => _target = value;
        }
    }
}
