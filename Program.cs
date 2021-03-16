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
            Graph adjacency_matrix = new Graph(vertices_arr, edges_arr);
            adjacency_matrix.PrintGraph();
            adjacency_matrix.Display();
            Console.Write("The distance of the route A-B-C is = ");
            Console.Write(adjacency_matrix.length(0,1)+adjacency_matrix.length(1,2));
            Console.WriteLine();
            
            Console.Write("The distance of the route A-D is = ");
            Console.Write(adjacency_matrix.length(0,3));
            Console.WriteLine();
            
            Console.Write("The distance of the route A-D-C is = ");
            Console.Write(adjacency_matrix.length(0,3)+adjacency_matrix.length(3,2));
            Console.WriteLine();
            
            Console.Write("The distance of the route A-E-B-C-D is = ");
            Console.Write(adjacency_matrix.length(0,4)+adjacency_matrix.length(4,1)+adjacency_matrix.length(1,2)+adjacency_matrix.length(2,3));
            Console.WriteLine();



        }
    }

}
