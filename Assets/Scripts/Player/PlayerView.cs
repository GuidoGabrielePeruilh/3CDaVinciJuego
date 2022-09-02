using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator myAnim;

    public void Start()
    {
    }
    public void DirView(Vector3 dir_view)
    {
        myAnim.SetFloat("Horizontal", dir_view.x);
        myAnim.SetFloat("Vertical", dir_view.z);
    }

    public void Shoot()
    {
        myAnim.SetBool("Shooting", true);
    }
    public void CancelShoot()
    {
        myAnim.SetBool("Shooting", false);
    }
}
