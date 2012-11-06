using Domain.DisjointSet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class DisjointSetUnionIntegrationTest {
        [TestMethod]
        public void DisjointSetUnionArrayTest() {
            var disjointSetUnionArray = new DisjointSetUnionArray(new[] {4, 3, 2, 1, 0});
            TestAgainstComplexInput(disjointSetUnionArray);
        }

        [TestMethod]
        public void DisjointSetUnionTreeTest() {
            var disjointSetUnionArray = new DisjointSetUnionTree(new[] {4, 3, 2, 1, 0});
            TestAgainstComplexInput(disjointSetUnionArray);
        }

        private static void TestAgainstComplexInput(IDisjointSetUnion<int> disjointSetUnion) {
            Assert.AreEqual(0, disjointSetUnion.Find(0));
            Assert.AreEqual(1, disjointSetUnion.Find(1));
            Assert.AreEqual(2, disjointSetUnion.Find(2));
            Assert.AreEqual(3, disjointSetUnion.Find(3));
            Assert.AreEqual(4, disjointSetUnion.Find(4));

            disjointSetUnion.Union(0, 4);
            disjointSetUnion.Union(1, 3);

            Assert.AreEqual(disjointSetUnion.Find(4), disjointSetUnion.Find(0));
            Assert.AreEqual(disjointSetUnion.Find(3), disjointSetUnion.Find(1));
            Assert.AreEqual(2, disjointSetUnion.Find(2));
        }
    }
}