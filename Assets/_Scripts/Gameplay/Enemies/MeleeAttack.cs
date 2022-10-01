using Game.Gameplay.Enemies.FollowMelee;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class MeleeAttack : MonoBehaviour
    {           
        [SerializeField] MetalEnemyAnimatorController _aniController;
        public void Attack()
        {            
            _aniController.Attack();
        }             
    }
}
