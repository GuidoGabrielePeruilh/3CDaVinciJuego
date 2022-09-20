using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public class MeleeAttack : MonoBehaviour
    {
        /*necesitamos:  que detecte cuando esta muy cerca y cambie el follow a attack.
        //se necesita un ataque.
        un objeto que ataque que aparezca en cierto momento y desaparezca
        necesitamos que reste vida al player;              
         */
        [SerializeField] Transform _attackPoint;
        [SerializeField] GameObject _sensorDamage;
        [SerializeField] Player _target;
        [SerializeField] MetalEnemyAC _aniController;
        [SerializeField] Move _move;

        private void Start()
        {
            
        }
        private void Update()
        {           
           _aniController.Attack();         
        }
    }
}
