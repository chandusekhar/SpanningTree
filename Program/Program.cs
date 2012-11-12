using System;
using System.Diagnostics;
using Domain;

namespace Program {
    internal static class Program {
        private static void Main() {
            Console.WriteLine("\nTask 3.1 Edges~=1/10*Vertexes^2");

            for (var i = 1; i < 1e4 + 1; i += 100) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateGraph(i, i*(i - 1)/10, 1, (int) 1e6);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };

                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.1 Full Graph");
            for (var i = 1; i < 1e4 + 1; i += 100) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateFullGraph(i, 1, (int) 1e6);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };
                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.2 Edges=100*Vertexes");
            for (var i = 201; i < 1e4 + 1; i += 100) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateGraph(i, 100*i, 1, (int) 1e6);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };

                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.2 Edges=1000*Vertexes");
            for (var i = 3001; i < 1e4 + 1; i += 100) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateGraph(i, 1000*i, 1, (int) 1e6);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };
                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.3");
            for (var i = (int) 1e5; i < 1e7; i += (int) 1e5) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateGraph((int) (1e4) + 1, i, 1, (int) 1e6);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };
                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.4 Full Graph");
            for (var i = 1; i <= 200; i++) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateFullGraph((int) (1e4) + 1, 1, i);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };

                Console.WriteLine(testResult);
            }

            Console.WriteLine("\nTask 3.4 Edges = 1000 * Vertexes");
            for (var i = 1; i <= 200; i++) {
                var stopWatch = new Stopwatch();
                var graph = GraphGenerator.GenerateGraph((int) (1e4) + 1, (int) 1e7, 1, i);

                stopWatch.Restart();
                var boruvkaSpanningTree = SpanningTree.Boruvka(graph);
                stopWatch.Stop();
                var burovkaTime = stopWatch.ElapsedTicks;

                stopWatch.Restart();
                var kruskalSpanningTree = SpanningTree.Kruskal(graph);
                stopWatch.Stop();
                var kruskalTime = stopWatch.ElapsedTicks;

                var kruskalWeight = kruskalSpanningTree.Weight;
                var burovkaWeight = boruvkaSpanningTree.Weight;

                var testResult = new TestResult {
                    Edges = graph.Edges.Count,
                    Vertexes = graph.Vertexes.Count,
                    WeightsMatched = burovkaWeight == kruskalWeight ? "Passed" : "Failed",
                    BurovkaTime = burovkaTime, KruskalTime = kruskalTime
                };
                Console.WriteLine(testResult);
            }
        }
    }

    internal class TestResult {
        public long BurovkaTime;
        public int Edges;
        public long KruskalTime;
        public int Vertexes;
        public string WeightsMatched;

        public override string ToString() {
            return string.Format("Edges: {0}\tVertexes: {1}\tWeights match: {2}", Edges, Vertexes, WeightsMatched)
                   + Environment.NewLine
                   + string.Format("Burovka time: {0}\tKruskal time: {1}", BurovkaTime, KruskalTime);
        }
    }
}