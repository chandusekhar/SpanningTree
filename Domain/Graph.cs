using System;
using System.Collections.Generic;

namespace Domain {
    public class Graph {
        public List<Vertex<int>> Vertexes { get; set; }
        public List<Edge<int>> Edges { get; set; }
    }

    public class Vertex<T> {
        public T Id { get; set; }
    }

    public class Edge<T> {
        public int Weight { get; set; }
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
    }

    public class WeightComparer<T> : IComparer<Edge<T>> {
        public int Compare(Edge<T> x, Edge<T> y) {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}