namespace DiGraph
{
    public interface Edge<Vertex>
    {
        Vertex GetStart();
        Vertex GetEnd();
        bool Contains(Vertex value);

        int GetWeight();
    }
}