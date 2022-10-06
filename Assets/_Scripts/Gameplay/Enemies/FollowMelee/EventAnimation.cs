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
        }
        public void Event_EndAnimation()
        {
            OnAttackEnds?.Invoke();
        }

        public void Event_StartHitbox()
        {
            _damage.SetActive(true);
        }
        
        public void Event_EndHitbox()
        {
            _damage.SetActive(false);
        }
    }
}
