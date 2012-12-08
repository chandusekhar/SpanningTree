using System;

namespace Domain {
    public class Edge<T> : IComparable<Edge<T>> {
        public Edge(T from, T to, int weight) {
            Weight = weight;
            From = from;
            To = to;
        }

        public int Weight { get; set; }
        public T From { get; private set; }
        public T To { get; private set; }

        public int CompareTo(Edge<T> other) {
            if (other.Weight > Weight)
                return -1;
            if (other.Weight == Weight)
                return 0;
            return 1;
        }
    }
}