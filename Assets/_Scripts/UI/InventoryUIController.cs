using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] Image[] _slotFrame;

        [Header("Colors")]
        [SerializeField] Color _activeColor;
        [SerializeField] Color _inacvtiveColor;

        int _currentIndex = 0;

        void Start()
        {
            _slotFrame[_currentIndex].color = _activeColor;
        }

        public void SetSlotColorActive(int index)
        {
            if (index == _currentIndex || index < 0 || index >= _slotFrame.Length) return;
            _slotFrame[_currentIndex].color = _inacvtiveColor;

            _currentIndex = index;
            _slotFrame[_currentIndex].color = _activeColor;
        }
    }
}
