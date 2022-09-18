using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
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

        private void Start()
        {
            
        }

        void Attack()
        {

        }
    }
}
