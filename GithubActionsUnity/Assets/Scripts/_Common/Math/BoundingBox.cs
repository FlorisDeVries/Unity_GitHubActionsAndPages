using UnityEngine;

namespace _Common.Math
{
    public class BoundingBox
    {
        public Vector2[] Positions { get; private set; }

        public BoundingBox(Vector2 p1, Vector2 p2)
        {
            // Min and Max to get 2 corners of rectangle regardless of drag direction.
            var bottomLeft = Vector3.Min(p1, p2);
            var topRight = Vector3.Max(p1, p2);

            // 0 = top left; 1 = top right; 2 = bottom left; 3 = bottom right;
            Positions = new []
            {
                new Vector2(bottomLeft.x, topRight.y),
                new Vector2(topRight.x, topRight.y),
                new Vector2(bottomLeft.x, bottomLeft.y),
                new Vector2(topRight.x, bottomLeft.y)
            };
        }
    }
}