// using System;
// using System.Collections.Generic;

// namespace DiGraph
// {
//     public class DirectedGraph<Vertex, Edge> : AbstractGraph<Vertex, Edge>
//     {
//         public override bool AddEdge(Vertex v1, Vertex v2, Edge weight)
//         {
//             if (v1 == null || v2 == null || weight == null)
//                 throw new ArgumentNullException();
//             if (!VertexSet.Contains(v1) || !VertexSet.Contains(v2))
//                 return false;
//             Edge<Vertex> pair = new Arc<Vertex>(v1, v2);
//             if (EdgeSet.Contains(pair))
//                 return false;
//             EdgeSet.Add(pair);
//             Weights[pair] = weight;
//             return true;
//         }

//         public override Edge GetWeight(Vertex v1, Vertex v2)
//         {
//             if (v1 == null || v2 == null)
//                 throw new ArgumentNullException();
//             Edge<Vertex> pair = new Arc<Vertex>(v1, v2);
//             if (!Weights.ContainsKey(pair))
//                 throw new ArgumentException();
//             return Weights[pair];
//         }

//         public override bool DeleteEdge(Vertex v1, Vertex v2)
//         {
//             if (v1 == null || v2 == null)
//                 throw new ArgumentNullException();
//             Edge<Vertex> pair = new Arc<Vertex>(v1, v2);
//             if (EdgeSet.Contains(pair))
//             {
//                 EdgeSet.Remove(pair);
//                 Weights.Remove(pair);
//                 return true;
//             }
//             return false;
//         }

//         public override bool AreAdjacent(Vertex v1, Vertex v2)
//         {
//             if (v1 == null || v2 == null)
//                 throw new ArgumentNullException();
//             if (!VertexSet.Contains(v1) || !VertexSet.Contains(v2))
//                 throw new ArgumentException();
//             return EdgeSet.Contains(new Arc<Vertex>(v1, v2));
//         }

//         public override int Degree(Vertex vertex)
//         {
//             if (vertex == null)
//                 throw new ArgumentNullException();
//             if (!VertexSet.Contains(vertex))
//                 throw new ArgumentException();
//             return InDegree(vertex) + OutDegree(vertex);
//         }

//         public override int OutDegree(Vertex vertex)
//         {
//             if (vertex == null)
//                 throw new ArgumentNullException();
//             if (!VertexSet.Contains(vertex))
//                 throw new ArgumentException();
//             int counter = 0;
//             foreach (var pair in EdgeSet)
//                 if (pair.GetFirst().Equals(vertex))
//                     counter++;
//             return counter;
//         }

//         public override int InDegree(Vertex vertex)
//         {
//             if (vertex == null)
//                 throw new ArgumentNullException();
//             if (!VertexSet.Contains(vertex))
//                 throw new ArgumentException();
//             int counter = 0;
//             foreach (var pair in EdgeSet)
//                 if (pair.GetSecond().Equals(vertex))
//                     counter++;
//             return counter;
//         }

//         public override IEnumerable<Vertex> AdjacenVertexertex(Vertex vertex)
//         {
//             foreach (Edge<Vertex> p in EdgeSet)
//                 if (p.GetFirst().Equals(vertex))
//                     yield return p.GetSecond();
//         }

//         public override Edge GetEdge(Vertex v1, Vertex v2)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }