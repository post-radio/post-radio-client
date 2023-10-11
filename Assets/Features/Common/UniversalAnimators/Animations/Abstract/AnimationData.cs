using System;
using UnityEngine;

namespace Common.UniversalAnimators.Animations.Abstract
{
    [Serializable]
    public class AnimationData
    {
        [SerializeField] private float _time;
        [SerializeField] private string _name;

        public float Time => _time;
        public string Name => _name;    
    }
}