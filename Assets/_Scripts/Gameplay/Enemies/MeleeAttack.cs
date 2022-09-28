using Game.Gameplay.Enemies.FollowMelee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class MeleeAttack : MonoBehaviour
    {           
        [SerializeField] MetalEnemyAC _aniController;             
        private void Update()
        {           
          _aniController.Attack();         
        }
    }
}
