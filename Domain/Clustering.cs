using System.Linq;
using Domain.DisjointSet;

namespace Domain {
    public static class Clustering {
        public static Graph Cluster(Graph graph) {
            var result = new Graph {
                                       Vertexes = graph.Vertexes
                                   };

            var edges = graph.Edges.ToList();
            edges.Sort();

            var disjointSetUnion = new DisjointSetUnionTree(graph.Vertexes);

            foreach (var edge in edges) {
                var fromRoot = disjointSetUnion.Find(edge.From);
                var toRoot = disjointSetUnion.Find(edge.To);

                if (fromRoot != toRoot) {
                    disjointSetUnion.Union(fromRoot, toRoot);
                    result.Edges.Add(edge);
                }
            }

            return result;
        }
    }
}