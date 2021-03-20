using System;

namespace DiGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            char [] vertices_arr = {'A', 'B', 'C', 'D', 'E'};
            string [] edges_arr = {"AB5", "BC4", "CD8", "DC8", "DE6", "AD5", "CE2", "EB3", "AE7"};
            // Console.WriteLine(vertices_arr[0]);
            Traverse traverse = new Traverse(vertices_arr, edges_arr);
            // array of routes
            int distance;
            
            // Case 1
            Console.Write("The distance of the route A-B-C is = ");
            char[] case1= {'A','B','C'};
            distance =traverse.distance(case1);
            if (distance==0){
                Console.WriteLine("No such route exists");
            }else{
                Console.Write(distance);
            }

            Console.WriteLine();
            
            // Case 2
            Console.Write("The distance of the route A-D is = ");
            char[] case2 = {'A','D'};
            distance =traverse.distance(case2);
            if (distance==0){
                Console.WriteLine("No such route exists");
            }else{
                Console.Write(distance);
            }

            Console.WriteLine();

            // Case 3
            Console.Write("The distance of the route A-D-C is = ");
            char[] case3 = {'A','D','C'};
            distance =traverse.distance(case3);
            if (distance==0){
                Console.WriteLine("No such route exists");
            }else{
                Console.Write(distance);
            }

            Console.WriteLine();
            
            // Case 4
            Console.Write("The distance of the route A-E-B-C-D is = ");
            char[] case4 = {'A','E','B','C','D'};
            distance =traverse.distance(case4);
            if (distance==0){
                Console.WriteLine("No such route exists");
            }else{
                Console.Write(distance);
            }

            Console.WriteLine();

            // Case 5
            Console.Write("The distance of the route A-E-D is = ");
            char[] case5 = {'A','E','D'};
            distance =traverse.distance(case5);
            if (distance==0){
                Console.WriteLine("No such route exists");
            }else{
                Console.Write(distance);
            }

            Console.WriteLine();

            // // Case 6
            traverse.pathsFrom('C','C');
            Console.WriteLine();

            // // Case 7
            traverse.pathsWithMaxStops('A','C',4);
            Console.WriteLine();
            
            // // // Case 8
            // Console.WriteLine("Using Djikstra's shortest path Algorithm");
            traverse.LengthOfShortestPath('A','C');
            Console.WriteLine();

            // // // Case 9
            // Console.WriteLine("Using Djikstra's shortest path Algorithm");
            traverse.LengthOfShortestPath('B','B');
            Console.WriteLine();

            // // // Case 10
            // Console.WriteLine("Using Djikstra's shortest path Algorithm and BFS.");
            // traverse.RoutesWithShortestPath('A','C', 30);
            // Console.WriteLine();
            




        }
    }

}
