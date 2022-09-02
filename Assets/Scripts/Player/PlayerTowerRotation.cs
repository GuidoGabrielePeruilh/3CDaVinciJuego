using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTowerRotation : MonoBehaviour
{
    [SerializeField] Vector3 input; //Para ver el mouse
    Camera myCamera;

    [Range(0, 100)] [SerializeField] float rootSpeed;

    private void Start()
    {
        myCamera = FindObjectOfType<Camera>(); //No es la mejor forma. Habria que hacerlo con un manager
    }
    private void Update()
    {
        input = Input.mousePosition;
        Ray ray = myCamera.ScreenPointToRay(input); //tira como un "rayo" a donde este el mouse. 
        //raycast accede a las librerias de fisica de unity. tira un rayo y devuelve un booleano y devuelve si detecto un rayp
        //
        RaycastHit hit;
        // el out modifica la variable real. Entra un hit, pero sale con la modificacion



        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point - transform.position; //Punto de donde choco en el mundo
            //transform.forward = point;//la ventaja de usar forward es que le podemos usar un smooth
            point.y = 0; // para que no mire ni para arriba ni para abajo
            //smooth
            transform.forward = Vector3.Slerp(transform.forward, point, rootSpeed * Time.deltaTime);
        }
    }
}
