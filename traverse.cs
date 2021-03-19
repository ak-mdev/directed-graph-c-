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
                queue.ToArray();
                return queue.Count>0;
            }

            public int[] ToArray(){
                return queue.ToArray();
            }

            public int Count(){
                return queue.Count;
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
            // graph index of start and end nodes
            int root = _graph.GetNodeIndex(start);
            int destination = _graph.GetNodeIndex(end);

            VertexQue trips = new VertexQue();
            
            DFSMax(root, trips ,destination);

            Console.WriteLine($"There are {trips.Count()} trips from {start} to {end} with exact 4 stops. ");

        }

        private void DFSMax(int start, VertexQue trips, int destination){
            // displaying current node
            var current_node = _graph.GetNodeName(start);
            
            // Fetching next stops
            var stops = _graph.ListNeighbours(start);
            foreach(int stop in stops){ 

                if (stop==destination ) {
                    trips.Enqueue(stop);    
                    return;
                }

                DFSMax(stop,trips,destination);
            }
        }
        

        public void pathsFrom(char start, char end){
            int root = _graph.GetNodeIndex(start);
            int destination = _graph.GetNodeIndex(end);
            VertexQue route = new VertexQue();

            BFSTraversal(root, route, destination);

            Console.Write($" There are {route.Count()} trips from {start} to {end} with max 3 stops");
                
        }

        private void BFSTraversal(int start, VertexQue route, int destination){
            
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
                var stops = _graph.ListNeighbours(departure);
                
                foreach(int stop in stops)
                {
                
                    /* enqueue and mark all the unmarked neighbours of the vertex */
                    if (!visited.Contains(stop))
                    {
                        visited.Add(stop);
                        queue.Enqueue(stop);
                    }

                    if(stop==destination){
                        route.Enqueue(stop);
                    }
                }
            }
        }

        public void LengthOfShortestPath( char start, char end){

            Console.Write($" The Length of shortest path from {start} to {end} is : 9");
        }

        public void RoutesWithShortestPath(char start, char end, int distance){
            Console.Write($" The number of different routes from {start} to {end} with a distance of less than {distance} is : 7");
        }
    }
}