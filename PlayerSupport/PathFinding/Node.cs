using System.Collections.Generic;
using Godot;

namespace TradingCompany.Game.Ai.PathFinding
{
    public class Node
    {
        public readonly List<Edge> Edges = new List<Edge>();

        public Node(Vector2 room)
        {
            Room = room;
        }

        public Room Room { get; }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
    }
}