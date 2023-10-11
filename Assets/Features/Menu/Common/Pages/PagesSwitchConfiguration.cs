using System;
using UnityEngine;

namespace Menu.Common.Pages
{
    [Serializable]
    public class PagesSwitchConfiguration
    {
        [SerializeField] [Min(0f)] private float _elementSwitchDelay = 0.02f;

        public float ElementSwitchDelay => _elementSwitchDelay;
    }
}