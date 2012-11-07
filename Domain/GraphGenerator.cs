using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DisjointSet;

namespace Domain {
    public static class GraphGenerator {
        private static readonly Random random = new Random();

        public static Graph GenerateGraph(int vertexes, int edges, int weightFrom, int weightTo) {
            var result = GenerateTree(vertexes);

            var alredyGeneratedEdges = new HashSet<Tuple<int, int>>();

            foreach (var edge in result.Edges) {
                alredyGeneratedEdges.Add(new Tuple<int, int>(edge.From, edge.To));
                alredyGeneratedEdges.Add(new Tuple<int, int>(edge.To, edge.From));
            }

            while (result.Edges.Count != edges) {
                var from = random.Next(vertexes);
                var to = random.Next(vertexes);

                if (from == to) continue;

                if (alredyGeneratedEdges.Contains(Tuple.Create(from, to))) continue;

                alredyGeneratedEdges.Add(new Tuple<int, int>(to, from));
                alredyGeneratedEdges.Add(new Tuple<int, int>(from, to));

                result.Edges.Add(new Edge<int>(from, to, 0));
            }

            foreach (var edge in result.Edges) {
                edge.Weight = random.Next(weightFrom, weightTo + 1);
            }

            return result;
        }

        public static Graph GenerateTree(int vertexes) {
            var result = new Graph {
                Vertexes = Enumerable.Range(0, vertexes).ToList()
            };

            var disjointSet = new DisjointSetUnionTree(result.Vertexes);

            while (result.Edges.Count < result.Vertexes.Count - 1) {
                var from = random.Next(vertexes);
                var to = random.Next(vertexes);

                if (from == to || disjointSet.Find(from) == disjointSet.Find(to)) continue;

                result.Edges.Add(new Edge<int>(from, to, 0));
                disjointSet.Union(from, to);
            }

            return result;
        }
    }
}