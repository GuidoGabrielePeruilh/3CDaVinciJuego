using UnityEngine;

namespace Game
{
    public class TiltablePlatform : MonoBehaviour
    {     
        private void FixedUpdate()
        {           
            transform.Rotate(new Vector3(0, 60f, 0) * Time.deltaTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(transform);
            }
        }
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }
}
