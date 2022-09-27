using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class AniController : MonoBehaviour
    {
        [SerializeField] Animator _myAni;
        [SerializeField] Move _move;    

        void Update()
        {
            _myAni.SetFloat("Horizontal", _move.Velocity.x);
            _myAni.SetFloat("Vertical", _move.Velocity.z);
        }

        public void attackmelee()
        {

        }
    }
}
