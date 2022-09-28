using System;
using System.Collections.Generic;
using Game.Gameplay.Weapon;
using UnityEngine;

namespace Game.Player
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> _weapons;
        [SerializeField] PlayerAnimationManager _animationManager;
        GameObject _current;
        int _currentIndex = 0;

        public List<GameObject> Inventory => new List<GameObject>(_weapons);
        void Awake()
        {
            foreach (var weapon in _weapons)
                weapon?.SetActive(false);

            if (_weapons[0] != null)
            {
                _currentIndex = 0;
                _current = _weapons[0];
                _current.SetActive(true);
                SubscribeCurrentAnimations();
            }
        }

        public GameObject CurrentWeapon => _current;

        public void ChangeToNextWeapon()
        {
            var nextIndex = _currentIndex + 1;
            if (nextIndex >= _weapons.Count)
                nextIndex = 0;
            ChangeToWeapon(nextIndex);
        }

        public void ChangeToPreviousWeapon()
        {
            var previousIndex = _currentIndex - 1;
            if (previousIndex < 0)
                previousIndex = _weapons.Count - 1;
            ChangeToWeapon(previousIndex);
        }

        public void ChangeToWeapon(int slot)
        {
            if (slot < 0 || slot >= _weapons.Count) return;

            _current.SetActive(false);
            _current = _weapons[slot];
            _current.SetActive(true);
            _currentIndex = slot;
            SubscribeCurrentAnimations();
        }

        void SubscribeCurrentAnimations()
        {
            var weapon = _current.GetComponent<Weapon>();
            if (weapon ==  null) return;
            
            weapon.SubscribeToAnimationEvents(_animationManager);
            switch (weapon.type)
            {
                case Weapon.Type.MELEE:
                    _animationManager.HasPistol(false);
                    _animationManager.HasRifle(false);
                    break;
                case Weapon.Type.SHOOTER:
                    _animationManager.HasPistol(true);
                    _animationManager.HasRifle(false);
                    break;
                case Weapon.Type.PARTICLE:
                    break;
                default:
                    break;
            }
        }
    }
    
    
}
