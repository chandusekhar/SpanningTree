using System.Collections.Generic;

namespace Domain {
    public class WeightComparer<T> : IComparer<Edge<T>> {
        public int Compare(Edge<T> x, Edge<T> y) {
            return x.Weight.CompareTo(y.Weight);
        }
    }

    public class Edge<T> {
        public Edge(T from, T to, int weight) {
            Weight = weight;
            From = from;
            To = to;
        }

        public int Weight { get; private set; }
        public T From { get; private set; }
        public T To { get; private set; }
    }
}