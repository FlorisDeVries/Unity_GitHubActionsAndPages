using System.Collections.Generic;
using UnityEngine;

namespace _Common.Extensions
{
    public static class TransformExtensions
    {
        public static void DisableRenderersRecursive(this Transform parent)
        {
            if (parent.TryGetComponent<Renderer>(out var objRenderer))
            {
                objRenderer.enabled = false;
            }

            foreach (Transform child in parent)
            {
                DisableRenderersRecursive(child);
            }
        }

        public static List<Transform> GetChildren(this Transform parent)
        {
            var children = new List<Transform>();
            for (var i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i));
            }

            return children;
        }
        
    }
}