using UnityEngine;

namespace Game.Player
{
    public class WeaponsController : MonoBehaviour
    {
        [SerializeField] GameObject[] _weapons = new GameObject[3];
        GameObject _current;
        int _currentIndex = 0;

        public void ChangeToNextWeapon()
        {
            var nextIndex = _currentIndex + 1;
            if (nextIndex >= _weapons.Length)
                nextIndex = 0;
            ChangeToWeapon(nextIndex);
        }

        public void ChangeToPreviousWeapon()
        {
            var previousIndex = _currentIndex - 1;
            if (previousIndex >= _weapons.Length)
                previousIndex = 0;
            ChangeToWeapon(previousIndex);
        }

        public void ChangeToWeapon(int slot)
        {
            if (slot < 0 && slot >= _weapons.Length) return;

            _current.SetActive(false);
            _current = _weapons[slot];
            _current.SetActive(true);
        }
    }
}
