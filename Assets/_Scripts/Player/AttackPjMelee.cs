using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Player
{
    public class AttackPjMelee : MonoBehaviour
    {
        [SerializeField] GameObject _damaging;

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
      
    }
}
