using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Platform : MonoBehaviour
    {
        public Transform pos1;
        public Transform pos2;

        float _timer;
        bool _go;

        public AnimationCurve myCurve;
        float _last;

        private void Start()
        {
            _last = myCurve.keys[myCurve.keys.Length - 1].time;  
        }

        private void Update()
        {
            if (_timer < _last)
            {
                _timer = _timer + 1 * Time.deltaTime;

                Vector3 _pointa = _go ? pos1.position : pos2.position;
                Vector3 _pointb = _go ? pos2.position : pos1.position;
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
