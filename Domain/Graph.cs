using System.Collections.Generic;
using System.Linq;

namespace Domain {
    public class Graph {
        public Graph() {
            Vertexes = new List<int>();
            Edges = new List<Edge<int>>();
        }

        public List<int> Vertexes { get; set; }
        public List<Edge<int>> Edges { get; set; }

        public long Weight {
            get { return Edges.Aggregate<Edge<int>, long>(0, (current, edge) => current + edge.Weight); }
        }
    }
}