using System.Collections.Generic;
using System.Linq;
using Domain.DisjointSet;

namespace Domain {
    public static class SpanningTree {
        public static Graph Kruskal(Graph inputGraph) {
            var result = new Graph();
            result.Vertexes = inputGraph.Vertexes;

            var edges = inputGraph.Edges.ToList();
            edges.Sort(new WeightComparer<int>());

            var disjointSetUnion = new DisjointSetUnionTree(inputGraph.Vertexes);

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

        public static Graph Boruvka(Graph graph) {
            var result = new Graph();
            result.Vertexes = graph.Vertexes;

            var disjointForest = new DisjointSetUnionTree(result.Vertexes);

            while (result.Edges.Count < result.Vertexes.Count - 1) {
                var safe = new Dictionary<int, Edge<int>>();

                foreach (var edge in graph.Edges) {
                    var fromRoot = disjointForest.Find(edge.From);
                    var toRoot = disjointForest.Find(edge.To);

                    if (fromRoot != toRoot) {
                        if (!safe.ContainsKey(fromRoot) || edge.Weight < safe[fromRoot].Weight) {
                            safe[fromRoot] = edge;
                        }

                        if (!safe.ContainsKey(toRoot) || edge.Weight < safe[toRoot].Weight) {
                            safe[toRoot] = edge;
                        }
                    }
                }

                result.Edges.AddRange(safe.Values.Distinct());

                foreach (var edge in safe.Values) {
                    disjointForest.Union(edge.From, edge.To);
                }
            }

            return result;
        }
    }
}