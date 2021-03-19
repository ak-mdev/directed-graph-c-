# digraph

Directed Graph is generated using a List of vertices/nodes and arcs/edges

Adjacency_matrix = int [ , ] 

Adjaceny matrix is used to represent weighted edges (route cost)

Once graph is created Tree traversal Algorithms are used to search the graph

Breath First Search ---- O(V+E) 
searched layer by layer and is good when trying to find all possible paths from source node to destination.

Depth First Search ---- O(V+E)
This search method uses a reccursion to find a node and if node is not found in one branch we retrace back to traverse another branch till the condition is met. this happens over and over until condition is met. 


To find the shortest path Implement Djiktra Shortest path algorithm using
priority queue as data structure.