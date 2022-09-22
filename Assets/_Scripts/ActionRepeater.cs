using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class ActionRepeater : MonoBehaviour
    {
        [SerializeField] UnityEvent OnAction;
        [SerializeField] int _waitForShootInSeconds = 2;
        float _time = 0;
        void Update()
        {
            if (_time < _waitForShootInSeconds)
                _time += 1 * Time.deltaTime;
            else
            {
                OnAction?.Invoke();
                _time = 0;
            }
        }
    }
}