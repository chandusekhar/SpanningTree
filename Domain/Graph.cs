using System.Collections.Generic;

namespace Domain {
    public class Graph {
        public Graph() {
            Vertexes = new List<int>();
            Edges = new List<Edge<int>>();
        }

        public List<int> Vertexes { get; set; }
        public List<Edge<int>> Edges { get; set; }
    }
}