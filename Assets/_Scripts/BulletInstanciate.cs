using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BulletInstanciate : MonoBehaviour
    {
        //ESTE CODIGO NO ES FINAL, ES AUXILIAR PARA LA DEMOSTRACION DE LOS EFECTOS... SERA ELIMINADO ANTES DE MERGEAR
        public GameObject bullet;

        public void InstanciateBullet()
        {
            Transform b = Instantiate(bullet).GetComponent<Transform>();
            b.transform.position = transform.position;
            b.transform.forward = transform.forward;
        }
    }
}
