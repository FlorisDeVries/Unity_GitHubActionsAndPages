using System;
using System.Linq;
using UnityEngine;

namespace _Common.Extensions
{
    public static class GameObjectInterfaceExtensions
    {
        /// <summary>
        /// Returns all monobehaviours of an interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <param name="gameObject">GameObject on which to search for the interface</param>
        /// <param name="output">If found will include the interface</param>
        /// <returns></returns>
        public static bool TryGetInterface<T>(this GameObject gameObject, out T output)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            
            output = gameObject.GetInterfaces<T>().FirstOrDefault();
            return output != null;
        }

        /// <summary>
        /// Returns all monobehaviours of an interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T[] GetInterfaces<T>(this GameObject gameObject)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

            var mObjs = gameObject.GetComponents<MonoBehaviour>();

            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        /// <summary>
        /// Returns the first monobehaviour that is of the interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetInterface<T>(this GameObject gameObject)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

            return gameObject.GetInterfaces<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T GetInterfaceInChildren<T>(this GameObject gameObject)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return gameObject.GetInterfacesInChildren<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets all monobehaviours in children that implement the interface of type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static T[] GetInterfacesInChildren<T>(this GameObject gameObject)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

            var mObjs = gameObject.GetComponentsInChildren<MonoBehaviour>();
            if (mObjs.Length < 1) return new T[0];

            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }
    }
}