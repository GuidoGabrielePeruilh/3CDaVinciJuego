using UnityEngine;
using UnityEngine.UI;
using Game.SO;

namespace Game.UI
{
    public class HealthUIController : MonoBehaviour
    {
        [SerializeField] Slider _slider;
        [SerializeField] Image _sliderFillImage;
        [SerializeField] Gradient _colorVariention;

        [Header("Player's Life")]
        [SerializeField] IntSO _maxPlayerLife;
        [SerializeField] IntSO _actualPlayerLife;

        void Start()
        {
            SetSliderValue();
        }

        void Update()
        {
            SetSliderValue();
        }

        public void SetSliderValue()
        {
            float actualValue = _actualPlayerLife.value;
            float maxValue = _maxPlayerLife.value;

            float value = actualValue / maxValue;
            _slider.value = value;
            _sliderFillImage.color = _colorVariention.Evaluate(value);
        }
    }
}
