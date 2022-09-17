using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Platforms
{
    public class PlatformMovable : MonoBehaviour
    {

        [SerializeField] Transform _pos1;
        [SerializeField] Transform _pos2;

        float _timer;
        bool _go;

        [SerializeField] AnimationCurve myCurve;
        float _last;

        void Start()
        {
            _last = myCurve.keys[myCurve.keys.Length - 1].time;  
        }

        void Update()
        {
            if (_timer < _last)
            {
                _timer = _timer + 1 * Time.deltaTime;

                Vector3 _pointa = _go ? _pos1.position : _pos2.position;
                Vector3 _pointb = _go ? _pos2.position : _pos1.position;
                transform.position = Vector3.Lerp(_pointa, _pointb, myCurve.Evaluate(_timer / _last));
            }
            else
            {
                _timer = 0;
                _go = !_go;
            }



        }
    }
}
