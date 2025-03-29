using UnityEngine;

namespace _Common.Math
{
    public static class MathLibrary
    {
        /// <summary>
        /// Returns the direction adjusted to be tangent to a specified surface normal relatively to given up axis.
        /// </summary>
        /// <param name="direction">The direction to be adjusted.</param>
        /// <param name="normal">The surface normal.</param>
        /// <param name="up">The given up-axis.</param>

        public static Vector3 GetTangent(Vector3 direction, Vector3 normal, Vector3 up)
        {
            var right = Vector3.Cross(direction, up).normalized;
            var tangent = Vector3.Cross(normal, right);

            return tangent.normalized;
        }

        /// <summary>
        /// Projects a given point onto the plane defined by plane origin and plane normal.
        /// </summary>
        /// <param name="point">The point to be projected.</param>
        /// <param name="planeOrigin">A point on the plane.</param>
        /// <param name="planeNormal">The plane normal.</param>

        public static Vector3 ProjectPointOnPlane(Vector3 point, Vector3 planeOrigin, Vector3 planeNormal)
        {
            var toPoint = point - planeOrigin;
            var toPointProjected = Vector3.Project(toPoint, planeNormal.normalized);

            return point - toPointProjected;
        }

        /// <summary>
        /// Wrap an angle in degrees around 360 degrees.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        public static float WrapAngle(float degrees)
        {
            if (degrees > 360.0f)
                degrees -= 360.0f;
            else if (degrees < 0.0f)
                degrees += 360.0f;

            return degrees;
        }
        
        /// <summary>
        /// Wrap an angle in radians around 2*PI.
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float WrapAngleRad(float radians)
        {
            if (radians > 2 * Mathf.PI)
                radians -= 2 * Mathf.PI;
            else if (radians < 0.0f)
                radians += 2 * Mathf.PI;

            return radians;
        }

        /// <summary>
        /// Remaps a point inside a range to be scaled towards a different range.
        /// </summary>
        /// <param name="value">The point to be remapped.</param>
        /// <param name="min1">Minimum of initial range</param>
        /// <param name="max1">Maximum of initial range</param>
        /// <param name="min2">Minimum of target range</param>
        /// <param name="max2">Maximum of target range</param>
        public static float Remap(this float value, float min1, float max1, float min2, float max2)
        {
            return (value - min1) / (max1 - min1) * (max2 - min2) + min2;
        }

        public static float LinearInterpolationTwoPoints(float x1, float y1, float x2, float y2, float x)
        {
            return (y2 - y1) / (x2 - x1) * x
                   + (x2 * y1 - x1 * y2) / (x2 - x1);
        }
    }
}