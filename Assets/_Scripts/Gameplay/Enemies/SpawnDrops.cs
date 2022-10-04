
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class SpawnDrops : MonoBehaviour
    {
        [SerializeField] GameObject _drop1;
        [SerializeField] GameObject _drop2;
        [SerializeField] EnemyDamageable _lifeEnemy;
        int _randomDrop = Random.Range(0, 2);

        private void OnEnable()
        {
            _lifeEnemy.OnDeath += Drop;
        }
        private void OnDisable()
        {
            _lifeEnemy.OnDeath -= Drop;
        }
        private void Drop()
        {

            if (_randomDrop == 0)
            {
                Instantiate(_drop1, _lifeEnemy.transform);
            }
            //else
                //Instantiate(_drop2, _lifeEnemy.transform);
        }
    }
}
