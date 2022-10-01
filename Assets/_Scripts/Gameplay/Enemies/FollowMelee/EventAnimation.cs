using System;
using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class EventAnimation : MonoBehaviour
    {
        [SerializeField] GameObject _damage;
        public event Action OnAttackStarts, OnAttackEnds;

        void Awake()
        {
            _damage.SetActive(false);
        }
        public void Event_StartAnimation()
        {
            OnAttackStarts?.Invoke();
            Debug.Log("Event_StartAnimation");
        }
        public void Event_EndAnimation()
        {
            OnAttackEnds?.Invoke();
            Debug.Log("Event_EndAnimation");
        }

        public void Event_StartHeatbox()
        {
            _damage.SetActive(true);
            Debug.Log("Event_StartHeatbox");
        }
        
        public void Event_EndHeatbox()
        {
            _damage.SetActive(false);
            Debug.Log("Event_EndHeatbox");
        }
    }
}
