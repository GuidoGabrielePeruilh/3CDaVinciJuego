using UnityEngine;

namespace Game.SO
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Object/weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] int _maxBullets = 0;
        [SerializeField] int _maxReserveBullets = 0;
        public int MaxBullets
        {
            get => _maxBullets;
        }
        public int MaxReserveBullets
        {
            get => _maxReserveBullets;
        }
    }
}