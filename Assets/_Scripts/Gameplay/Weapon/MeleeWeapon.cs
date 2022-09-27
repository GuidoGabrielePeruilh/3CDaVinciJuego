using UnityEngine;

namespace Game.Gameplay.Weapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] GameObject _damaging;
        [SerializeField] Animator _ani;
              
        void Awake()
        {
            _damaging.SetActive(false);
        }
        [ContextMenu("empieza ataque")]
        public void Event_StartAnimation()
        {
            _damaging.SetActive(true);
        }
        [ContextMenu("se termino ataque")]
        public void Event_EndAnimation()
        {
            _damaging.SetActive(false);
        }

        public override void ShootBullet()
        {
            //TODO activar animacion de melee.
            
        }

        public override void ReloadWeapon()
        {
           
        }
    }
}
