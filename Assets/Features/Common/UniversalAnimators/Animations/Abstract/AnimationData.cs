using System;
using UnityEngine;

namespace Common.UniversalAnimators.Animations.Abstract
{
    [Serializable]
    public class AnimationData
    {
        public AnimationData(float time, string name)
        {
            _time = time;
            _name = name;
        }
        
        [SerializeField] private float _time;
        [SerializeField] private string _name;

        public float Time => _time;
        public string Name => _name;    
    }
}