using UnityEngine;

namespace _Common.Math
{
    public static class CameraMath
    {
        public static Mesh GenerateProjectedCube(BoundingBox boundingBox, Camera camera, float distance)
        {
            var corners = new Vector3[4];
            var edges = new Vector3[4];
            var index = 0;

            foreach (var position in boundingBox.Positions)
            {
                var ray = camera.ScreenPointToRay(position);
                var point = ray.origin + ray.direction * distance;
                
                corners[index] = point;
                edges[index] = ray.origin - point;
                Debug.DrawLine(camera.ScreenToWorldPoint(position), point, Color.red, 1.0f);
                
                index++;
            }
            
            var verts = new Vector3[8];
            int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the tris of our cube

            for(var i = 0; i < 4; i++)
            {
                verts[i] = corners[i];
            }

            for(var j = 4; j < 8; j++)
            {
                verts[j] = corners[j - 4] + edges[j - 4];
            }

            return new Mesh
            {
                vertices = verts,
                triangles = tris
            };
        }
    }
}