using System;
using Menu.Common.Tasks.Abstract;
using UnityEngine;

namespace Menu.Common.Tasks.Runtime
{
    [Serializable]
    public class TaskData : ITaskData
    {
        [SerializeField] private string _name;
        [SerializeField] [Multiline] private string _description;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
    }
}