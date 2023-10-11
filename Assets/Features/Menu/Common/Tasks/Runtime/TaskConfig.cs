using Menu.Common.Tasks.Abstract;
using Menu.Common.Tasks.Common;
using UnityEngine;

namespace Menu.Common.Tasks.Runtime
{
    [CreateAssetMenu(fileName = TaskRoutes.TaskConfigName, menuName = TaskRoutes.TaskConfigPath)]
    public class TaskConfig : ScriptableObject
    {
        [SerializeReference] private ITaskCompletionChecker _taskCompletionChecker;
    }
}