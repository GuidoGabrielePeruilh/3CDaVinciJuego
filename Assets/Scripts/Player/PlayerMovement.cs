using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    [SerializeField] float speed;
    [SerializeField] PlayerView myView;
    [SerializeField] Transform root;



    Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 dirview = root.InverseTransformDirection(input); //Al forward del input le da la flechita que necesitamos. Es para que se mueva en direccion de donde esta mirando
        myView.DirView(dirview);
    }

    private void FixedUpdate()
    {
        myRB.velocity = input * speed * Time.fixedDeltaTime;
    }
}
