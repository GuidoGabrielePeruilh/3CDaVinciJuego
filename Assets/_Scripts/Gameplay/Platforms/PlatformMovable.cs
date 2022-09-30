using UnityEngine;

namespace Game.Gameplay.Platforms
{
    public class PlatformMovable : MonoBehaviour
    {
        [SerializeField] Transform _point1;
        [SerializeField] Transform _point2;
        [SerializeField] AnimationCurve myCurve;
        float _timer;
        bool _go;
        float _last;

        void Start()
        {
            _last = myCurve.keys[myCurve.keys.Length - 1].time;
            Debug.Log(_last);
        }

        void Update()
        {
            if (_timer < _last)
            {
                _timer = _timer + 1 * Time.deltaTime;

                Vector3 _pointa = _go ? _point1.position : _point2.position;
                Vector3 _pointb = _go ? _point2.position : _point1.position;
                transform.position = Vector3.Lerp(_pointa, _pointb, myCurve.Evaluate(_timer / _last));
            }
            else
            {
                _timer = 0;
                _go = !_go;
            }                       
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
