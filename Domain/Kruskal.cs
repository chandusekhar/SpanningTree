using System.Linq;

namespace Domain {
    public class SpanningTreeBuilder {
        public Graph Kruskal(Graph inputGraph) {
            var result = new Graph {
                Vertexes = inputGraph.Vertexes
            };

            var edges = inputGraph.Edges.ToList();
            edges.Sort(new WeightComparer<int>());

            var disjointSetUnion = new DisjointSetUnionTree(inputGraph.Vertexes.Select(_ => _.Id));

            foreach (var edge in edges) {
                var i1 = disjointSetUnion.Find(edge.From.Id);
                var i2 = disjointSetUnion.Find(edge.To.Id);
                if (i1 != i2) {
                    disjointSetUnion.Union(i1, i2);
                    result.Edges.Add(edge);
                }
            }

            return inputGraph;
        }
    }
}