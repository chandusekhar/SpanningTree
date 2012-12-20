using System.Linq;
using Domain.DisjointSet;

namespace Domain {
    public static class Clustering {
        public static int Cluster(Graph graph, int clusterCount) {
            var result = new Graph {
                                       Vertexes = graph.Vertexes
                                   };

            var edges = graph.Edges.ToList();
            edges.Sort();
            var enumerator = edges.GetEnumerator();

            var disjointSetUnion = new DisjointSetUnionTree(graph.Vertexes);

            while (disjointSetUnion.Count != clusterCount - 1) {
                enumerator.MoveNext();
                var edge = enumerator.Current;

                var fromRoot = disjointSetUnion.Find(edge.From);
                var toRoot = disjointSetUnion.Find(edge.To);

                if (fromRoot != toRoot) {
                    disjointSetUnion.Union(fromRoot, toRoot);
                    result.Edges.Add(edge);
                }
            }

            return enumerator.Current.Weight;
        }
    }
}