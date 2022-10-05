using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class SpawnDrops : MonoBehaviour
    {
        [SerializeField] GameObject _drop1;
        [SerializeField] GameObject _drop2;
        [SerializeField] EnemyDamageable _lifeEnemy;
        [SerializeField, Range(0f, 1f)] float _chancePercentage = 0;
        float _chance = Random.Range(0f, 1f);

        void OnEnable()
        {
            _lifeEnemy.OnDeath += Drop;
        }
        void OnDisable()
        {
            _lifeEnemy.OnDeath -= Drop;
        }
        void Drop()
        {
            if (_chance <= _chancePercentage)
            {
                Instantiate(_drop1, transform.position, Quaternion.identity);
            }
            else
                Instantiate(_drop1, transform.position, Quaternion.identity);
        }
    }
}
