using UnityEngine;

namespace _Common.Extensions
{
    public static class ExtraGizmos
    {
        /// <summary>
        /// Draw an Gizmo in the shape of an arrow
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="direction"></param>
        /// <param name="arrowHeadLength"></param>
        /// <param name="arrowHeadAngle"></param>
        public static void DrawArrow(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.2f, float arrowHeadAngle = 20.0f)
        {
            // Arrow shaft
            Gizmos.DrawRay(pos, direction);

            if (direction == Vector3.zero) return;
            
            // Arrow head
            var right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            var left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
            Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
        }
    }
}