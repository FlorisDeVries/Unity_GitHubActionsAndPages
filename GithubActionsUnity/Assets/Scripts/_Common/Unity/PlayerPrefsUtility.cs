using UnityEngine;

namespace _Common.Unity
{
    public static class PlayerPrefsUtility
    {
        private const string LoadedFromEditorKey = "LoadedFromEditor";
        
        public static bool LoadedFromEditor
        {
            get => PlayerPrefs.GetInt(LoadedFromEditorKey, 0) == 1;
            set => PlayerPrefs.SetInt(LoadedFromEditorKey, value ? 1 : 0);
        }
    }
}