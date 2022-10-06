using UnityEngine;

namespace Game.Player
{
    public class PointerTarget : MonoBehaviour
    {
        [SerializeField] Camera camera;
        Ray ray;
        RaycastHit hitInfo;

        void Update()
        {
            ray.origin = camera.transform.position;
            ray.direction = camera.transform.forward;
            Physics.Raycast(ray, out hitInfo);
            transform.position = hitInfo.point;
        }
    }
}