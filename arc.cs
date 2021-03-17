using System;

namespace DiGraph
{
    public class Arc <Vertex> : Edge<Vertex>
    {
        private readonly Vertex _t1;
        private readonly Vertex _t2;

        private readonly int _weight ;
        public Arc(Vertex t1, Vertex t2, int weight)
        {
            if (t1 == null || t2 == null || weight <= 0)
                throw new ArgumentNullException();
            if (t1.GetType() != t2.GetType())
                throw new ArgumentException();
            _t1 = t1;
            _t2 = t2;
            _weight = weight;
        }

        public Vertex GetStart()
        {
            return _t1;
        }

        public Vertex GetEnd()
        {
            return _t2;
        }

        public int GetWeight()
        {
            return _weight;
        }

        public bool Contains(Vertex node)
        {
            return _t1.Equals(node) || _t2.Equals(node);
        }

        public override bool Equals(object o)
        {
            if (o == null || o.GetType() != typeof(Arc<Vertex>))
                return false;
            Arc<Vertex> casted = (Arc<Vertex>) o;
            return casted._t1.Equals(_t1) && casted._t2.Equals(_t2);
        }

        public override int GetHashCode()
        {
            return _t1.GetHashCode() + _t2.GetHashCode();
        }

    }
}