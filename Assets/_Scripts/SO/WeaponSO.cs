using UnityEngine;

namespace Game.SO
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Object/weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] int _maxAmunicion = 0;
        [SerializeField] int _maxReserveAmunicion = 0;
        public int MaxAmunicion => _maxAmunicion;
        public int MaxReserveAmunicion => _maxReserveAmunicion;
    }
}