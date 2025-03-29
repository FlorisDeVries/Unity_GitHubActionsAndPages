using UnityEngine;

namespace _Common.Extensions
{
    public static class FloatExtensions
    {
        public static Vector3 ToVector3(this float value)
        {
            return new Vector3(value, value, value);
        }
    }

}