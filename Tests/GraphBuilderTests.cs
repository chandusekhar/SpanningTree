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
    }
}