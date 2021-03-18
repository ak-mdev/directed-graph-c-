using System;
using System.Collections.Generic;

namespace DiGraph
{
    class Traverse{
        Graph _graph;
        public Traverse(char [] nodes_input , string[] edges_input){
            _graph = new Graph(nodes_input,edges_input);
        }

        class VertexQue{
            Queue<int> queue = new Queue<int>();

            public void Enqueue(int vertex){
                queue.Enqueue(vertex);
            }

            public int Dequeue(){
                return queue.Dequeue(); 
            }

            public bool NotEmpty(){
                return queue.Count>0;
            }

        }

        class VertexMarkSet{
            // HashSet can only contain unique values 
            // this is good for checking if a node has been visited or not
            HashSet<int> markSet= new HashSet<int>();
            public void Add (int vertex){
                markSet.Add(vertex);
            }

            public bool Contains(int vertex){
                return markSet.Contains(vertex);
            }

        }

        private void DepthFirstTraversal(int start, VertexMarkSet visited, int destination, int hops, int max_hops){
            // displaying current node
            var node_name = _graph.GetNodeName(start);
            Console.Write(node_name);

            // Fetching next stops
            var stops = _graph.ListNeighbours(start);
            foreach(int stop in stops){ 
                var stop_name= _graph.GetNodeName(stop);
                Console.Write(" --> ");
                // Console.Write(destination_name); 
                if (hops == max_hops  || visited.Contains(stop) && destination==stop_name) {
                    Console.Write(_graph.GetNodeName(stop));
                    Console.Write($" Reached destination in {hops} stops");
                    Console.WriteLine();
                    return;
                }

                // cycle detection initiated
                if (destination==stop_name){
                    visited.Add(start);
                }

                DepthFirstTraversal(stop,visited,destination,hops+1, max_hops);
            }
        }

        public void BreathFirstTraversal(int start){
            /* make a queue of vertices */
            var queue = new VertexQue();
            /* make a mark set of vertices */
            var visited = new VertexMarkSet();
            /* enqueue and mark start */
            queue.Enqueue(start);
            visited.Add(start);
            /* while the queue is not empty */
            while(queue.NotEmpty())
            {
                /* dequeue a vertext */
                var departure = queue.Dequeue();
                var destinations = _graph.ListNeighbours(departure);
                Console.WriteLine(_graph.GetNodeName(departure));
                foreach(int destination in destinations)
                {
                    // Console.WriteLine(" v ");
                    Console.WriteLine(_graph.GetNodeName(destination));
                    if (destination == 2) {
                        Console.WriteLine(" Reached destination ");
                    }
                    /* enqueue and mark all the unmarked neighbours of the vertex */
                    if (!visited.Contains(destination))
                    {
                        // Console.Write(_graph.GetNodeName(destination));
                        visited.Add(destination);
                        queue.Enqueue(destination);
                    }
                    Console.WriteLine();
                }
            }
        }

        public int distance(char [] route)//returns a distance for a route that consists of multiple nodes
        {
            int distance =0;
            int start_node;
            int end_node;
            for(int i=0; i<route.Length-1; i++){
                // stores node index if a node is found
                start_node = _graph.GetNodeIndex(route[i]);
                end_node = _graph.GetNodeIndex(route[i+1]);

                if(!_graph.Adjacent(start_node,end_node)){
                    distance=0;
                    break; 
                }
                distance+=_graph.GetEdgeWeight(start_node, end_node);
            }
            return distance;
        }

        public void pathsWithMaxStops(char start , char end, int max_hops){
            int root = _graph.GetNodeIndex(start);
            int destination = _graph.GetNodeIndex(end);

            List<int[]> paths = new List<int[]>();
            var visited = new VertexMarkSet();
            int hops =1;

            DepthFirstTraversal(root,visited,destination,hops, max_hops);

        }

    //     public void pathsWithExactStops(char start, char end, int stops){

    //     }

    // }
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
        //     //insert all remaining nodes into the pq
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
        // private void printPath(int[] path, int start, int end)
        // {
        //     //prints a path, given a start and end, and an array that holds previous 
        //     //nodes visited
        //     Console.WriteLine("Shortest path from source to destination:");
        //     int temp = end;
        //     Stack<int> s = new Stack<int>();
        //     while (temp != start)
        //     {
        //         s.Push(temp);
        //         temp = path[temp];
        //     }
        //     Console.Write("{0} ", temp);//print source
        //     while (s.Count != 0)
        //     {
        //         Console.Write("{0} ", s.Pop());//print successive nodes to destination
        //     }
        // }
    }
}