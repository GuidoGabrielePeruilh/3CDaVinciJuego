using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SliderController : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] Image sliderFillImage;
        [SerializeField] Gradient colorVariention;

        public void SetSliderValue(int actualValue, int maxValue)
        {
            float aValue = actualValue;
            float mValue = maxValue;
            SetSliderValue(aValue, mValue);
        }

        public void SetSliderValue(float actualValue, float maxValue)
        {
            float value = actualValue / maxValue;
            slider.value = value;
            sliderFillImage.color = colorVariention.Evaluate(value);
        }


    }
}
