using System;
using System.Collections.Generic;
using System.Linq;

namespace _Common.Extensions
{
    public static class CollectionExtensions
    {
        public static T Random<T>(this IEnumerable<T> src)
        {
            return src.ToArray().Random();
        }
        
        public static T Random<T>(this T[] array)
        {
            var index = UnityEngine.Random.Range(0, array.Length);
            return array.Length < 1 ? default : array[index];
        }  
        
        public static T Next<T>(this T src) where T : Enum
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) + 1;
            return (arr.Length==j) ? arr[0] : arr[j];            
        }
    }
}