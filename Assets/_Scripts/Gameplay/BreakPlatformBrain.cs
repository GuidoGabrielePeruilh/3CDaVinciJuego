using System;
using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public class BreakPlatformBrain : MonoBehaviour
    {
        [SerializeField] OnPlayerOver _onPlayerOver;
        [SerializeField, Range(0f, 5f)] float _timeToBreakLayer = 5;
        [SerializeField] int _maxLayers = 3;
        [SerializeField, Range(.1f, 10f)] int _timeToRespawn = 0;
        [SerializeField] Collider _collider;
        float _time = 0;
        int _currentLayer = 3;
        
        public event Action<int> OnChangeLayer;
        public int MaxLayers => _maxLayers;
        public int CurrentLayer => _currentLayer;

        void Awake()
        {
            _currentLayer = _maxLayers;
        }

        void Update()
        {
            if (_onPlayerOver.IsPlayerOver && _currentLayer != 0)
            {
                _time += 1 * Time.deltaTime;
            }

            if (_time >= _timeToBreakLayer && _currentLayer > 0)
            {
                _time = 0;
                _currentLayer--;
                OnChangeLayer?.Invoke(_currentLayer);
                if (_currentLayer <= 0)
                {
                    _collider.enabled = false;
                    _onPlayerOver.Reset();
                }
            }

            if (_currentLayer == 0)
            {
                _time += 1 * Time.deltaTime;
                if (_time >= _timeToRespawn)
                {
                    _currentLayer = _maxLayers;
                    _time = 0;
                    OnChangeLayer?.Invoke(_currentLayer);
                    _collider.enabled = true;
                }
            }
        }
    }
}
