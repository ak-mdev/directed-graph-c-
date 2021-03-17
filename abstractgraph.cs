using System;
using System.Collections.Generic;

namespace DiGraph
{
    public abstract class AbstractGraph <Vertex,Edge> : IGraph<Vertex,Edge>
    {
        protected readonly List<Vertex> VertexSet = new List<Vertex>();
        protected readonly List<Edge<Vertex>> EdgeSet = new List<Edge<Vertex>>();
        protected readonly Dictionary<Edge<Vertex>, Edge> Edges = new Dictionary<Edge<Vertex>, Edge>();
        public bool AddVertex(Vertex vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (VertexSet.Contains(vertex))
                return false;
            VertexSet.Add(vertex);
            return true;
        }
        public void AddVertex(IEnumerable<Vertex> set)
        {
            if (set == null)
                throw new ArgumentNullException();
            using (var it = set.GetEnumerator())
                while (it.MoveNext())
                    if (it.Current != null && !VertexSet.Contains(it.Current))
                        VertexSet.Add(it.Current);
        }
        public void DeleteVertex(IEnumerable<Vertex> set)
        {
            if (set == null)
                throw new ArgumentNullException();
            using (var it = set.GetEnumerator())
                while (it.MoveNext())
                    if (it.Current != null)
                        VertexSet.Remove(it.Current);
        }
        public bool DeleteVertex(Vertex vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException();
            if (!VertexSet.Contains(vertex))
                return false;
            VertexSet.Remove(vertex);
            return true;
        }
        public IEnumerable<Vertex> GeVertexertexSet()
        {
            foreach (Vertex vertex in VertexSet)
                yield return vertex;
        }

        public IEnumerable<Edge<Vertex>> GetEdgeSet()
        {
            foreach (Edge<Vertex> edge in EdgeSet)
                yield return edge;
        }

        public int VertexNumber()
        {
            return VertexSet.Count;
        }
        public int EdgeNumber()
        {
            return EdgeSet.Count;
        }
        public abstract bool AddEdge(Vertex v1, Vertex v2, Edge weigth);
        public abstract Edge GetEdge(Vertex v1, Vertex v2);

        public abstract bool DeleteEdge(Vertex v1, Vertex v2);
        public abstract bool AreAdjacent(Vertex v1, Vertex v2);
        public abstract int Degree(Vertex vertex);
        public abstract int OutDegree(Vertex vertex);
        public abstract int InDegree(Vertex vertex);
        public abstract IEnumerable<Vertex> AdjacenVertexertex(Vertex vertex);

        public bool AddNode(Vertex node)
        {
            throw new NotImplementedException();
        }

        public void AddNode(IEnumerable<Vertex> nodes)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNode(Vertex node)
        {
            throw new NotImplementedException();
        }

        public void DeleteNode(IEnumerable<Vertex> nodes)
        {
            throw new NotImplementedException();
        }

        public bool AddEdge(Vertex v1, Vertex v2, int weigth)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Edge<Vertex>> IGraph<Vertex, Edge>.GetEdgeSet()
        {
            throw new NotImplementedException();
        }

        public int GetWeight(Vertex v1, Vertex v2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vertex> AdjacentVertex(Vertex node)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vertex> GetVertexSet()
        {
            throw new NotImplementedException();
        }
    }
}