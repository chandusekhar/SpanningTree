using System.Diagnostics;
using System.Linq;
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
        public void CanBuildSpanningTreeUsingKruskalAlgorithm() {
            var kruskal = SpanningTree.Kruskal(inputGraph);
            Assert.AreEqual(8, kruskal.Vertexes.Count);
            Assert.AreEqual(7, kruskal.Edges.Count);
            Assert.AreEqual(71, kruskal.Edges.Sum(_ => _.Weight));
        }

        [TestMethod]
        public void CanBuildSpanningTreeUsingBoruvkaAlgorithm() {
            var boruvka = SpanningTree.Boruvka(inputGraph);
            Assert.AreEqual(8, boruvka.Vertexes.Count);
            Assert.AreEqual(7, boruvka.Edges.Count);
            Assert.AreEqual(71, boruvka.Edges.Sum(_ => _.Weight));
        }

        [TestMethod]
        public void IntegrationTest() {
            var graph = GraphGenerator.GenerateGraph(10000, 500000, 1, 400);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var boruvka = SpanningTree.Boruvka(graph);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);

            stopwatch.Restart();
            var kruskal = SpanningTree.Kruskal(graph);
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.ElapsedTicks);

            Assert.AreEqual(boruvka.Edges.Select(_ => _.Weight).Sum(), kruskal.Edges.Select(_ => _.Weight).Sum());
        }
    }
}