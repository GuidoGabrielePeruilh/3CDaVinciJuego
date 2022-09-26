using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class Test : MonoBehaviour
    {
        public SliderController control;

        public int maxValue;
        public int actualValue;

        // Start is called before the first frame update
        void Start()
        {
            actualValue = maxValue;
        }

        // Update is called once per frame
        void Update()
        {
            control.SetSliderValue(actualValue, maxValue);
        }
    }
}
