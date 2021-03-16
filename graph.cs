using System;
using System.Collections.Generic;
using System.IO;

namespace DiGraph
{
    class Graph
    {
        class Vertex
        {
            public int index;
            public char data;
            public Vertex(char data, int index)
            {
                this.index = index;
                this.data = data;
            }
        }

        class Edge {
            private Vertex start;
            private Vertex end;
            private int weight;
            public Edge(Vertex start, Vertex end, int weight)
            {
                this.start=start;
                this.end=end;
                this.weight=weight;
            }
        }
        /// <summary>
        /// 4 attributes
        /// A list of vertices (to store node information for each index such as name/text)
        /// a 2D array - our adjacency matrix, stores edges between vertices
        /// a graphSize integer
        /// a StreamReader, to read in graph data to create the data structure
        /// </summary>
        private List<Vertex> vertices;
        private List<Edge> edges;
        private int graphSize;

        // private StreamReader sr;
        private int[,] adjMatrix;
        private const int infinity = 9999;
        public Graph(char [] vertices_input, String [] edges_input)
        {
            // Generating a list of Vertices V= {V1, V2, V3,..}
            vertices = new List<Vertex>();
            for (int i=0; i<vertices_input.Length; i++)
            {
                vertices.Add(new Vertex(vertices_input[i], i));
            }
            CreateGraph();

            // Generating a list of Edges E= {E1, E2, E3,..}
            for (int i=0; i<edges_input.Length; i++ )
            {
                // parsing input
                char startstr = edges_input[i][0];
                char endstr = edges_input[i][1];
                int weight = (int)Char.GetNumericValue(edges_input[i][2]);
                Vertex start = vertices.Find(v => v.data == startstr);
                Vertex end = vertices.Find(v => v.data == endstr);
                
                // edges.Add(new Edge(start,end,weight));
                AddEdge(start.index,end.index,weight);
            }
        }
        private void CreateGraph()
        {
            //get the graph size first
            graphSize = vertices.Count;//non-zero arrays, add 1
            adjMatrix = new int[graphSize, graphSize];
            
            //ASSUME ALL DATA HAS BEEN READ FROM A TEXT FILE & ADJACENCY MATRIX HAS BEEN INITIALIZED
        }

        public void PrintGraph()
        {
            for (int i= 0; i< graphSize; i++ )
            {
                for ( int j =0; j<graphSize; j++)
                {
                    Console.Write(adjMatrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        // public void RunDijkstra()//runs dijkstras algorithm on the adjacency matrix
        // {
        //     Console.WriteLine("***********Dijkstra's Shortest Path***********");
        //     int[] distance = new int[graphSize];
        //     int[] previous = new int[graphSize];
        //     for (int i = 1; i < graphSize; i++)
        //     {
        //         distance[i] = infinity;
        //         previous[i] = 0;
        //     }
        //     int source = 1;
        //     distance = 0;
        //     PriorityQueue<int> pq = new PriorityQueue<int>();
        //     //enqueue the source
        //     pq.Enqueue(source, adjMatrix);
        //     //insert all remaining vertices into the pq
        //     for (int i = 1; i < graphSize; i++)
        //     {
        //         for (int j = 1; j < graphSize; j++)
        //         {
        //             if (adjMatrix[i, j] > 0)
        //             {
        //                 pq.Enqueue(i, adjMatrix[i, j]);
        //             }
        //         }
        //     }
        //     while (!pq.Empty())
        //     {
        //         int u = pq.dequeue_min();
        //         for (int v = 1; v < graphSize; v++)//scan each row fully
        //         {
        //             if (adjMatrix[u,v] > 0)//if there is an adjacent node
        //             {
        //                 int alt = distance[u] + adjMatrix[u, v];
        //                 if (alt < distance[v])
        //                 {
        //                     distance[v] = alt;
        //                     previous[v] = u;
        //                     pq.Enqueue(u, distance[v]);
        //                 }
        //             }
        //         }
        //     }
        //     //distance to 1..2..3..4..5..6 etc lie inside each index

        //     for (int i = 1; i < graphSize; i++)
        //     {
        //         Console.WriteLine("Distance from {0} to {1}: {2}", source, i, distance[i]);
        //     }
        //     printPath(previous, source, graphSize - 1);
        // }
        private void printPath(int[] path, int start, int end)
        {
            //prints a path, given a start and end, and an array that holds previous 
            //nodes visited
            Console.WriteLine("Shortest path from source to destination:");
            int temp = end;
            Stack<int> s = new Stack<int>();
            while (temp != start)
            {
                s.Push(temp);
                temp = path[temp];
            }
            Console.Write("{0} ", temp);//print source
            while (s.Count != 0)
            {
                Console.Write("{0} ", s.Pop());//print successive nodes to destination
            }
        }
        public void AddEdge(int vertexA, int vertexB, int distance)
        {
            // if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
            // {
                adjMatrix[vertexA, vertexB] = distance;
            // }
        }
        public void RemoveEdge(int vertexA, int vertexB)
        {
            if (vertexA > 0 && vertexB > 0 && vertexA <= graphSize && vertexB <= graphSize)
            {
                adjMatrix[vertexA, vertexB] = 0;
            }
        }
        public bool Adjacent(int vertexA, int vertexB)
        {   //checks whether two vertices are adjacent, returns true or false
            return (adjMatrix[vertexA, vertexB] > 0);
        }
        public int length(int vertex_u, int vertex_v)//returns a distance between 2 nodes
        {
            return adjMatrix[vertex_u, vertex_v];
        }
        public void Display() //displays the adjacency matrix
        {
            Console.WriteLine("***********Adjacency Matrix Representation***********");
            Console.WriteLine("Number of nodes: {0}\n", graphSize);
            Console.Write("\t");
            foreach (Vertex n in vertices)
            {
                Console.Write("{0}\t", n.data);
            }
            Console.WriteLine();
            Console.WriteLine();//newline for the graph display
            for (int i = 0; i < graphSize; i++)
            {
                Console.Write("{0}\t", vertices[i].data);
                for (int j = 0; j < graphSize; j++)
                {
                    Console.Write("{0}\t", adjMatrix[i,j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Read the graph from left to right");
        }
        private void DisplayVertex(int v)//displays data/description for a node
        {
            Console.WriteLine(vertices[v].data);
        }
    }

}