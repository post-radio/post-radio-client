using UnityEngine;

namespace Menu.Common.Tasks.Abstract
{
    public interface ITaskData
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}