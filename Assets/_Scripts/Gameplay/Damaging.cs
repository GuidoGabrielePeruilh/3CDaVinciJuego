using UnityEngine;

namespace Game.Gameplay
{
    public class Damaging : MonoBehaviour
    {
        [SerializeField] int _damage = 0;

        void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable == null) return;
            
            damageable.TakeTamage(_damage);
            DestroySelf();
        }

        void DestroySelf()
        {
            gameObject.SetActive(false);
        }
    }
}
