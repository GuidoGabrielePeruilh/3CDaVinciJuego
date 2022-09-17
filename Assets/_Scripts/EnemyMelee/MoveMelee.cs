using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveMelee : MonoBehaviour
    {
        [SerializeField] List<Transform> positions;
        float _timer;
        [SerializeField] float _time_to_close = 5;
        int _index = 0;
        

        private void Start()
        {

        }
        private void Update()
        {
            if (_timer < _time_to_close)
            {
                _timer += Time.deltaTime;
                if (_index == positions.Count - 1)
                {
                    transform.position = Vector3.Lerp(positions[_index].position, positions[0].position, _timer/_time_to_close);
                }
                else
                {
                    transform.position = Vector3.Lerp(positions[_index].position, positions[_index + 1].position, _timer / _time_to_close);
                }
                   
            }
            else
            {
                _timer = 0;
                NextIndex();
            }
        }


        void NextIndex()
        {
            if (_index == positions.Count - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
                
            }
        }
    }
}
