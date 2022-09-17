using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class patrullaje : MonoBehaviour
    {
        public int routine;
        public float chronometer;
        public Animator animator;
        public Quaternion angle;
        public float grado;

        public void Comportamiento_Enemi()
        {
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 2)
            {
                routine = Random.Range(0, 2);
            }
            switch (routine)
            {
                case 0:
                    animator.SetBool("Walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grado, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animator.SetBool("Walk", true);
                    break;
            }
        }
        private void Update()
        {
            Comportamiento_Enemi();
        }
    }
}
