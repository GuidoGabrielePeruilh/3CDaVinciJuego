using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _lifeTime;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}
