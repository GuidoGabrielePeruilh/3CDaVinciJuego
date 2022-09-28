using System;
using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] Animator _myAni;
        // [SerializeField] Move _move;
        Dictionary<string, Action> _events = new Dictionary<string, Action>();

        public void ADD_ANI_EVENT(string eventName, Action callback)
        {
            if (_events.ContainsKey(eventName)) return;
            _events.Add(eventName, callback);
        }

        public void REMOVE_ANI_EVENT(string eventName, Action callback)
        {
            _events.Remove(eventName);
        }
        public void PLAYER_EVENT(string eventName)
        {
            Debug.Log(eventName);
            _events[eventName]?.Invoke();
        }

        void Update()
        {
            // _myAni.SetFloat("Horizontal", _move.Velocity.x);
            // _myAni.SetFloat("Vertical", _move.Velocity.z);
        }

        public void HasPistol(bool value)
        {
            // _myAni.SetBool("HasPistol", value);
        }
        
        public void HasRifle(bool value)
        {
            // _myAni.SetBool("HasRifle", value);
        }
        
        public void AttackMelee()
        {
            HasPistol(false);
            HasRifle(false);
            _myAni.SetTrigger("MeleeTrigger");
        }

        public void AttackShooter()
        {
            HasPistol(true);
            HasRifle(false);
            _myAni.SetTrigger("PistolTrigger");
        }
    }
}
