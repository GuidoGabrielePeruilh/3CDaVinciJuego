using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Platform : MonoBehaviour
    {
        public Transform pos1;
        public Transform pos2;

        float timer;
        bool go;

        public AnimationCurve myCurve;
        float last;

        private void Start()
        {
            last = myCurve.keys[myCurve.keys.Length - 1].time;  
        }

        private void Update()
        {
            if (timer < last)
            {
                timer = timer + 1 * Time.deltaTime;

                Vector3 a = go ? pos1.position : pos2.position;
                Vector3 b = go ? pos2.position : pos1.position;
                transform.position = Vector3.Lerp(a, b, myCurve.Evaluate(timer / last));
            }
            else
            {
                timer = 0;
                go = !go;
            }



        }
    }
}
