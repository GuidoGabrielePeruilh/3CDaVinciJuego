using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EventAnimation : MonoBehaviour
    {

        [SerializeField] GameObject _damage;

        private void Awake()
        {
            _damage.SetActive(false);
        }
        public void Event_StartAnimation()
        {
            _damage.SetActive(true); 
        }
        public void Event_EndAnimation()
        {
            _damage.SetActive(false);
        }
    }
}