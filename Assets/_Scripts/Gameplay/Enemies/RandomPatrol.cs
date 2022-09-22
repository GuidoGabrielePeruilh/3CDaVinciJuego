using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class RandomPatrol : MonoBehaviour
    {
        [SerializeField] List<Transform> positions;
        int _indexRandom = 0;
        [SerializeField] Move _move;
        [SerializeField, Range(0, 5)] float _speed = 1;
        [SerializeField] float _distance = 1;

        void Update()
        {
            Vector3 target = positions[_indexRandom].position;

            if (Vector3.Distance(transform.position, positions[_indexRandom].position) >= _distance)
            {
                _move.Velocity = (target - transform.position).normalized * _speed;
            }
            else
            {
                _move.Velocity = Vector3.zero;



                NextIndex();
            }
            transform.forward = target - transform.position;
        }

        public float Speed
        {
            set => _speed = value;
        }

        void NextIndex()
        {
            var newIndex = 0;
            do
            {
                newIndex = Random.Range(0, positions.Count);

            }
            while (newIndex == _indexRandom);
            _indexRandom = newIndex;
        }

    }
}
