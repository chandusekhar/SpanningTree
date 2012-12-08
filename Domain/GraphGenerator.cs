using System;
using System.IO;
using System.Linq;
using Domain.DisjointSet;
using Domain.HashSet;

namespace Domain {
    public static class GraphGenerator {
        private static readonly Random random = new Random();

        public static Graph GenerateGraph(int vertexes, int edges, int weightFrom, int weightTo) {
            var result = GenerateTree(vertexes);

            var alredyGeneratedEdges = new MyHashSet(vertexes);
            foreach (var edge in result.Edges) {
                alredyGeneratedEdges.Add(Tuple.Create(edge.From, edge.To));
            }

            while (result.Edges.Count != edges) {
                var from = random.Next(vertexes);
                var to = random.Next(vertexes);

                if (from == to) continue;

                if (alredyGeneratedEdges.Contains(Tuple.Create(from, to))) {
                    var newPair = NeedNewPair(alredyGeneratedEdges, Tuple.Create(from, to), vertexes);
                    from = newPair.Item1;
                    to = newPair.Item2;
                }

                alredyGeneratedEdges.Add(Tuple.Create(from, to));

                result.Edges.Add(new Edge<int>(from, to, 0));
            }

            foreach (var edge in result.Edges) {
                edge.Weight = random.Next(weightFrom, weightTo + 1);
            }

            return result;
        }

        private static Tuple<int, int> NeedNewPair(MyHashSet alredyGeneratedEdges, Tuple<int, int> value, int vertexes) {
            var from = value.Item1;
            var to = value.Item2;

            for (var i = from; i < vertexes; i++) {
                for (var j = to; j < vertexes; j++) {
                    var tuple = Tuple.Create(i, j);
                    if (!alredyGeneratedEdges.Contains(tuple)) {
                        return tuple;
                    }
                }
            }

            for (var i = from; i >= 0; i--) {
                for (var j = to; j >= 0; j--) {
                    var tuple = Tuple.Create(i, j);
                    if (!alredyGeneratedEdges.Contains(tuple)) {
                        return tuple;
                    }
                }
            }

            throw new Exception("Check edges count");
        }

        public static Graph GenerateTree(int vertexes) {
            var result = new Graph();

            for (var i = 0; i < vertexes; i++) {
                result.Vertexes.Add(i);
            }

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

        public static Graph GenerateFullGraph(int vertexes, int weightFrom, int weightTo) {
            var result = new Graph();

            for (var i = 0; i < vertexes; i++) {
                result.Vertexes.Add(i);
            }

            for (var i = 0; i < vertexes; i++) {
                for (var j = i + 1; j < vertexes; j++) {
                    var weight = random.Next(weightFrom, weightTo + 1);
                    result.Edges.Add(new Edge<int>(i, j, weight));
                }
            }

            return result;
        }

        public static Graph GenerateFromFile(string path) {
            var reader = new StreamReader(path);
            var firstLine = reader.ReadLine().Split(' ');
            var vertexes = Convert.ToInt32(firstLine[0]);
            var edges = Convert.ToInt32(firstLine[1]);

            var graph = new Graph {
                Vertexes = Enumerable.Range(0, 500).ToList()
            };

            for (var i = 0; i < edges; i++) {
                var line = reader.ReadLine().Split(' ');
                var from = Convert.ToInt32(line[0]) - 1;
                var to = Convert.ToInt32(line[1]) - 1;
                var weight = Convert.ToInt32(line[2]);
                graph.Edges.Add(new Edge<int>(from, to, weight));
            }

            return graph;
        }
    }
}