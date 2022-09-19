using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ParciclesController : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particle;
        [Range(1, 10)][SerializeField] float _delayOff;

        private void Start()
        {
            TurnOff();
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
            _particle.Play();

        }

        public void TurnOff()
        {
            _particle.Stop();
            Invoke("GameObjectOff", _delayOff);
        }

        private void GameObjectOff()
        {
            gameObject.SetActive(false);
        }

    }
}
