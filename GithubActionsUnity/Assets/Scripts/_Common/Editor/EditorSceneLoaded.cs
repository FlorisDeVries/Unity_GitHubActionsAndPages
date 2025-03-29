#if UNITY_EDITOR
using _Common.Unity;
using UnityEditor;

namespace _Common.Editor
{
    [InitializeOnLoad]
    public class EditorSceneLoaded
    {
        static EditorSceneLoaded()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                PlayerPrefsUtility.LoadedFromEditor = true;
            }
        }
    }
}
#endif