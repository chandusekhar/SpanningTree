using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.DisjointSet {
    public class DisjointSetUnionTree : IDisjointSetUnion<int> {
        private readonly Random random = new Random();
        private readonly int[] tree;

        public DisjointSetUnionTree(IEnumerable<int> enumerable) {
            var ints = enumerable as int[] ?? enumerable.ToArray();
            var count = ints.Count();
            Count = count;
            tree = new int[count];
            for (var i = 0; i < count; i++) {
                tree[ints[i]] = ints[i];
            }
        }

        public int Find(int item) {
            if (tree[item] == item) {
                return item;
            }
            return tree[item] = Find(tree[item]);
        }

        public void Union(int item1, int item2) {
            var i1 = Find(item1);
            var i2 = Find(item2);
            if (random.Next()%2 == 0) {
                tree[i1] = i2;
            } else {
                tree[i2] = i1;
            }
            Count--;
        }

        public int Count { get; private set; }
    }
}