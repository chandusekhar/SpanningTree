using System.Diagnostics;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class SpanningTreeTests {
        private Graph inputGraph;

        [TestInitialize]
        public void Init() {
            inputGraph = new Graph();
            inputGraph.Vertexes.Add(0);
            inputGraph.Vertexes.Add(1);
            inputGraph.Vertexes.Add(2);
            inputGraph.Vertexes.Add(3);
            inputGraph.Vertexes.Add(4);
            inputGraph.Vertexes.Add(5);
            inputGraph.Vertexes.Add(6);
            inputGraph.Vertexes.Add(7);
            inputGraph.Edges.Add(new Edge<int>(0, 1, 6));
            inputGraph.Edges.Add(new Edge<int>(0, 2, 11));
            inputGraph.Edges.Add(new Edge<int>(0, 3, 17));
            inputGraph.Edges.Add(new Edge<int>(1, 2, 25));
            inputGraph.Edges.Add(new Edge<int>(3, 2, 8));
            inputGraph.Edges.Add(new Edge<int>(7, 2, 2));
            inputGraph.Edges.Add(new Edge<int>(7, 5, 14));
            inputGraph.Edges.Add(new Edge<int>(7, 6, 21));
            inputGraph.Edges.Add(new Edge<int>(4, 5, 9));
            inputGraph.Edges.Add(new Edge<int>(4, 1, 19));
        }

        [TestMethod]
        public void CanBuildSpanningTreeUsingNaivePrimAlgorithm() {
            var prim = SpanningTree.NaivePrim(inputGraph);
            AssertSimpleSpanningTree(prim);
        }

        [TestMethod]
        public void CanBuildSpanningTreeUsingKruskalAlgorithm() {
            var kruskal = SpanningTree.Kruskal(inputGraph);
            AssertSimpleSpanningTree(kruskal);
        }

        [TestMethod]
        public void CanBuildSpanningTreeUsingBoruvkaAlgorithm() {
            var boruvka = SpanningTree.Boruvka(inputGraph);
            AssertSimpleSpanningTree(boruvka);
        }

        [TestMethod]
        public void IntegrationTest() {
            var graph = GraphGenerator.GenerateGraph(1000, 5000, 1, 400);
            var stopwatch = new Stopwatch();

            stopwatch.Restart();
            var boruvka = SpanningTree.Boruvka(graph);
            stopwatch.Stop();
            Debug.WriteLine("Boruvka : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            var kruskal = SpanningTree.Kruskal(graph);
            stopwatch.Stop();
            Debug.WriteLine("Kruskal : {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            var prim = SpanningTree.NaivePrim(graph);
            stopwatch.Stop();
            Debug.WriteLine("NaivePrim : {0}", stopwatch.ElapsedTicks);

            Assert.AreEqual(boruvka.Weight, prim.Weight);
            Assert.AreEqual(boruvka.Weight, kruskal.Weight);
        }

        private static void AssertSimpleSpanningTree(Graph graph) {
            Assert.AreEqual(8, graph.Vertexes.Count);
            Assert.AreEqual(7, graph.Edges.Count);
            Assert.AreEqual(71, graph.Weight);
        }
    }
}