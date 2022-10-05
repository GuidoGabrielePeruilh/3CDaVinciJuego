using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Enemies.FlyerPatrol
{
    public abstract class State
    {
        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();

        public State NextState { get; set; }
       
    }
}
