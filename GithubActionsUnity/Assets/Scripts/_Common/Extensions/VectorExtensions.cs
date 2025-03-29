using UnityEngine;

namespace _Common.Extensions
{
    public static class VectorExtensions
    {
        /// <summary>
        /// Performs a CW rotation of n degrees
        /// </summary>
        /// <param name="v"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            var sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            var cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            var tx = v.x;
            var ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }

        public static Vector3 Flatten(this Vector3 v, float y = 0)
        {
            return new Vector3(v.x, y, v.z);
        }

        public static Vector2 Round(this Vector2 v)
        {
            return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
        }

        public static Vector3 Round(this Vector3 v)
        {
            return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
        }

        public static Vector2 Floor(this Vector2 v)
        {
            return new Vector2(Mathf.Floor(v.x), Mathf.Floor(v.y));
        }

        public static Vector3 Floor(this Vector3 v)
        {
            return new Vector3(Mathf.Floor(v.x), Mathf.Floor(v.y), Mathf.Floor(v.z));
        }

        public static Vector3 ToVector3(this Vector2 v, float y = 0)
        {
            return new Vector3(v.x, y, v.y);
        }

        public static float RandomInRange(this Vector2 v)
        {
            return Random.Range(v.x, v.y);
        }    
        
        public static Vector3 MidpointTo(this Vector3 origin, Vector3 target, float maxDistance = 0)
        {
            var midpoint = (origin + target) / 2.0f;

            if (!(maxDistance > 0)) return midpoint;
            
            var actualDistance = Vector3.Distance(origin, midpoint);

            if (!(actualDistance > maxDistance)) return midpoint;
            
            var direction = (target - origin).normalized;
            midpoint = origin + direction * maxDistance;

            return midpoint;
        }
    }
}