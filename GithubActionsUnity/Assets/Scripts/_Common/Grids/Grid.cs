using System.Collections.Generic;
using _Common.Grids.Pathfinding;
using _Common.Unity;
using UnityEngine;

namespace _Common.Grids
{
    public class Grid<T> where T : GridTile
    {
        private T[,] _grid;
        
        public int Width => _grid.GetLength(0);
        public int Height => _grid.GetLength(1);

        public AStarPathfinder<T> Pathfinder;

        public Grid(int width, int height)
        {
            _grid = new T[width, height];
            Pathfinder = new AStarPathfinder<T>(this);
        }

        public T Get(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return default;
            }
            
            return _grid[x, y];
        }
        
        public T Get(Vector2Int position)
        {
            return Get(position.x, position.y);
        }

        public void Set(int x, int y, T value)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }
            
            _grid[x, y] = value;
        }
        
        public void Set(Vector2Int position, T value)
        {
            Set(position.x, position.y, value);
        }
        
        public void Generate(T prefab, int layer, Transform parent = null)
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var instance = Object.Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
                    instance.name = $"{prefab.name} {x} {y}";
                    instance.gameObject.layer = layer;
                    if (parent)
                        instance.transform.SetParent(parent);
                    instance.Setup();
                    Set(x, y, instance);
                }
            }
        }
        
        public List<T> GetNeighbours(int x, int y)
        {
            var neighbours = new List<T>();
            
            if (x - 1 >= 0)
                neighbours.Add(Get(x - 1, y));
            if (x + 1 < Width)
                neighbours.Add(Get(x + 1, y));
            if (y - 1 >= 0)
                neighbours.Add(Get(x, y - 1));
            if (y + 1 < Height)
                neighbours.Add(Get(x, y + 1));
            
            return neighbours;
        }
        
        public Vector2Int CalculateGridPosition(Vector3 position)
        {
            return new Vector2Int(Mathf.FloorToInt(position.x + .5f), Mathf.FloorToInt(position.y + .5f));
        }

        public T GetCenter()
        {
            return Get(Width / 2, Height / 2);
        }
    }
}