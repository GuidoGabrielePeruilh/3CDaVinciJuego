using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField, Range(0f, 10f)] float _speedRotation = 10f;

        void Update()
        {
            var targetDirection = _target.transform.position - transform.position;
            transform.forward = Vector3.Slerp(transform.forward, targetDirection,Time.deltaTime * _speedRotation);
        }

        public GameObject Target
        {
            get => _target;
            set => _target = value;
        }
    }
}
