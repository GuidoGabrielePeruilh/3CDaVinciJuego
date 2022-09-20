using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Platforms
{
    public class BreakPlatformAC : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] BreakPlatformBrain _platformBrain;
        [SerializeField] MeshRenderer _renderer;
        [Tooltip("It has to have the same amount of colors as the max layers in the BreakPlatformBreak")]
        [SerializeField] List<Color> _layerColors;
        void Awake()
        {
            if (_layerColors.Count < _platformBrain.MaxLayers)
                throw new Exception(
                    "The Layers Colors have to have the same amount of colors as the max layers in the BreakPlatformBreak");
            _platformBrain.OnChangeLayer += ChangeLayer;
            ChangeLayer(_platformBrain.CurrentLayer);
        }

        void ChangeLayer(int layer)
        {
            if (layer <= 0)
            {
                _renderer.enabled = false;
                return;
            }

            _renderer.enabled = true;
            _renderer.material.color = _layerColors[layer - 1];
        }
    }
}
