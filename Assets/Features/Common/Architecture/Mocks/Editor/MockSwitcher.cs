using Common.Architecture.Mocks.Runtime;
using UnityEditor;
using UnityEngine;

namespace Common.Architecture.Mocks.Editor
{
    [InitializeOnLoad]
    public static class MockSwitcher
    {
        static MockSwitcher()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode)
                return;

            var mock = Object.FindFirstObjectByType<MockBase>();

            if (mock == null)
                return;

            mock.Process().Forget();
        }
    }
}