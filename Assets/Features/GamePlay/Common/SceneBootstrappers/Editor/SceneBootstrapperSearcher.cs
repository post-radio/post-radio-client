using System.Collections.Generic;
using GamePlay.Common.SceneBootstrappers.Runtime;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Common.SceneBootstrappers.Editor
{
    public class SceneBootstrapperSearcher : AssetModificationProcessor
    {
        private static string[] OnWillSaveAssets(string[] paths)
        {
            var storage = Object.FindObjectOfType<SceneBootstrapper>();

            if (storage == null)
                return paths;
            
            var registers = Object.FindObjectsOfType<SceneComponentRegister>(true);
            var builders = Object.FindObjectsOfType<SceneComponentBuilder>(true);
            
            Undo.RecordObject(storage, "Set builders");
            storage.SetTargets(registers, builders);
            

            return paths;
        }

        private static ISceneComponentBuildersStorage FindSceneObjectsHandler(IEnumerable<MonoBehaviour> behaviours)
        {
            foreach (var behaviour in behaviours)
                if (behaviour is ISceneComponentBuildersStorage filler)
                    return filler;

            return null;
        }
    }
}