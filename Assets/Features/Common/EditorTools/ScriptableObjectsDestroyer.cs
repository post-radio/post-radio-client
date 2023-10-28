﻿using UnityEditor;
using UnityEngine;

namespace Common.EditorTools
{
    public class ScriptableObjectsDestroyer
    {
        [MenuItem("Assets/Destroy Nested Objects", priority = -1000)]
        private static void DestroyObject()
        {
            if (Selection.objects == null)
                return;

            foreach (var target in Selection.objects)
            {
                Object.DestroyImmediate(target, true);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
}