using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] Animator _myAni;
        Dictionary<string, Action> _events = new Dictionary<string, Action>();

        public void ADD_ANI_EVENT(string eventName, Action callback)
        {
            if (_events.ContainsKey(eventName)) return;
            _events.Add(eventName, callback);
        }

        public void REMOVE_ANI_EVENT(string eventName)
        {
            _events.Remove(eventName);
        }
        public void PLAYER_EVENT(string eventName)
        {
            _events[eventName]?.Invoke();
        }
        
        public void AttackMelee()
        {
            _myAni.SetTrigger("MeleeTrigger");
        }

        public void AttackShooter()
        {
            _myAni.SetTrigger("PistolTrigger");
        }
    }
}
