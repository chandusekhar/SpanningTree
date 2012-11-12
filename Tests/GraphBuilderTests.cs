using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class GraphBuilderTests {
        [TestMethod]
        public void CanBuildTree() {
            var tree = GraphGenerator.GenerateTree(10);
            GraphGenerator.GenerateGraph(10, 15, 2, 3);

            Assert.AreEqual(10, tree.Vertexes.Count);
            Assert.AreEqual(9, tree.Edges.Count);
        }

        [TestMethod]
        public void CanBuildGraph() {
            var generateGraph = GraphGenerator.GenerateGraph(4, 6, 2, 3);

            Assert.AreEqual(4, generateGraph.Vertexes.Count);
            Assert.AreEqual(6, generateGraph.Edges.Count);
        }

        [TestMethod]
        public void CanBuildFullGraph() {
            const int vertexes = 10000;
            var generateGraph = GraphGenerator.GenerateFullGraph(vertexes, 2, 3);

            Assert.AreEqual(vertexes, generateGraph.Vertexes.Count);
            Assert.AreEqual(vertexes*(vertexes - 1)/2, generateGraph.Edges.Count);
        }

        [TestMethod]
        public void CanBuildBigGraph() {
            const int vertexes = 100;
            var generateGraph = GraphGenerator.GenerateGraph(vertexes, vertexes*(vertexes - 1)/2, 1, 1);

            Assert.AreEqual(vertexes, generateGraph.Vertexes.Count);
            Assert.AreEqual(vertexes*(vertexes - 1)/2, generateGraph.Edges.Count);
        }
    }
}