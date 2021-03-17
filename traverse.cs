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
                if(queue.Count>0){
                    return true;
                }else{
                    return true;
                }
            }

        }

        class VertexMarkSet{
            List<int> markSet= new List<int>();
            public void Add (int vertex){
                markSet.Add(vertex);
            }

            public bool Contains(int vertex){
                return markSet.Contains(vertex);
            }

        }

        private void DepthFirstTraversal(){

        }

        private void BreathFirstTraversal(int start){
            /* make a queue of vertices */
            var queue = new VertexQue();
            /* make a mark set of vertices */
            var markSet = new VertexMarkSet();
            /* enqueue and mark start */
            queue.Enqueue(start);
            markSet.Add(start);
            /* while the queue is not empty */
            while(queue.NotEmpty())
            {
                /* dequeue a vertext */
                var vertex = queue.Dequeue();
                foreach(int neighbour in _graph.ListNeighbours(vertex))
                {
                    /* enqueue and mark all the unmarked neighbours of the vertex */
                    if (!markSet.Contains(neighbour))
                    {
                        markSet.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
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

    //     public void pathsWithMaxStops(char start , char end, int max_hops){
    //         int root = nodes.Find(node => node.data == start).index;
    //         int destination = nodes.Find(node => node.data == end).index;

    //         int trips =0;
    //         int current=root;
    //         int next;
    //         int paths;

    //     }

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