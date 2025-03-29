using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Common.Grids.Pathfinding
{
    public class AStarPathfinder<T> where T : GridTile
    {
        private readonly Grid<T> _grid;

        public AStarPathfinder(Grid<T> grid)
        {
            _grid = grid;
        }

        public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
        {
            var openSet = new List<Node>();
            var closedSet = new HashSet<Node>();
            var startNode = new Node(start, null, 0, GetHeuristic(start, target));
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                openSet.Sort((node1, node2) => node1.F.CompareTo(node2.F));
                var currentNode = openSet[0];

                if (currentNode.Position == target)
                {
                    return ReconstructPath(currentNode);
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                foreach (var neighbour in _grid.GetNeighbours(currentNode.Position.x, currentNode.Position.y))
                {
                    if ((neighbour.Position != start && neighbour.Position != target && !neighbour.IsTraversable())
                        || closedSet.Any(n => n.Position == neighbour.Position))
                        continue;

                    var tentativeGScore = currentNode.G + 1;
                    var neighbourNode = openSet.FirstOrDefault(n => n.Position == neighbour.Position);

                    if (neighbourNode == null)
                    {
                        neighbourNode = new Node(neighbour.Position, currentNode, tentativeGScore,
                            GetHeuristic(neighbour.Position, target));
                        openSet.Add(neighbourNode);
                    }
                    else if (tentativeGScore < neighbourNode.G)
                    {
                        neighbourNode.G = tentativeGScore;
                        neighbourNode.Parent = currentNode;
                    }
                }
            }

            return new List<Vector2Int>();
        }

        private List<Vector2Int> ReconstructPath(Node currentNode)
        {
            var path = new List<Vector2Int>();
            while (currentNode != null)
            {
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        private int GetHeuristic(Vector2Int pointA, Vector2Int pointB)
        {
            // Manhattan distance
            return Mathf.Abs(pointA.x - pointB.x) + Mathf.Abs(pointA.y - pointB.y);
        }

        class Node
        {
            public Vector2Int Position { get; }
            public Node Parent { get; set; }
            public int G { get; set; } // Cost from start to current node
            public int H { get; } // Heuristic cost estimate from current node to end
            public int F => G + H; // Total cost

            public Node(Vector2Int position, Node parent, int g, int h)
            {
                Position = position;
                Parent = parent;
                G = g;
                H = h;
            }
        }
    }
}