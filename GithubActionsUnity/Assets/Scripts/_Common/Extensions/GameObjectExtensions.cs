using _Common.Unity;
using UnityEngine;

namespace _Common.Extensions
{
    public static class GameObjectExtensions
    {
        public static GameObject SetLayer(this GameObject gameObject, int layer, bool includeChildren = false)
        {
            gameObject.layer = layer;
            if (!includeChildren) return gameObject;

            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetLayer(layer, true);
            }

            return gameObject;
        }

        public static GameObject SetLayer(this GameObject gameObject, UnityLayer layer, bool includeChildren = false)
        {
            return gameObject.SetLayer((int)layer, includeChildren);
        }
    }
}