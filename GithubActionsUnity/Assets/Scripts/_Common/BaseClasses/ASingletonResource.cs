using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace _Common.BaseClasses
{
    /// <summary>
    /// Override ResourcePath to specify the path to the resource!!
    /// Can be used to create a singleton resource that is loaded from the Resources folder
    /// Usage example: (ASingletonResource).Instance.DoSomething();
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ASingletonResource<T> : ScriptableObject where T : ASingletonResource<T>
    {
        protected abstract string ResourcePath { get; }

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance) return _instance;

                var path = GetResourcePathStatic();
                _instance = UnityEngine.Resources.Load<T>(path);
                if (_instance) return _instance;

#if UNITY_EDITOR
                // Create resource if it doesn't exist
                _instance = CreateInstance<T>();
                _instance.name = typeof(T).Name;

                CreateDirectory();
                AssetDatabase.CreateAsset(_instance, GetAssetPath());
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                LogWarning(path);
#endif

                return _instance;
            }
        }

        private static string GetResourcePathStatic()
        {
            var tempInstance = CreateInstance<T>();
            var path = tempInstance.ResourcePath;
            DestroyImmediate(tempInstance);
            return path;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        // In separate method to avoid performance warning on all usages
        private static void LogWarning(string path)
        {
            Debug.LogWarning($"Resource of type {typeof(T)} created at {path}");
        }

        private static void CreateDirectory()
        {
            var assetPath = GetAssetPath();
            var directory = Path.GetDirectoryName(assetPath);
            if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static string GetAssetPath()
        {
            return $"Assets/Resources/{GetResourcePathStatic()}.asset";
        }
    }
}