using System.Collections.Generic;
using System.Linq;

namespace Domain.DisjointSet {
    public class DisjointSetUnionArray : IDisjointSetUnion<int> {
        private readonly int[] array;

        public DisjointSetUnionArray(IEnumerable<int> enumerable) {
            var ints = enumerable as int[] ?? enumerable.ToArray();
            var count = ints.Count();
            Count = count;
            array = new int[count];
            for (var i = 0; i < count; i++) {
                array[ints[i]] = ints[i];
            }
        }

        public int Find(int item) {
            return array[item];
        }

        public void Union(int item1, int item2) {
            var i1 = array[item1];
            var i2 = array[item2];

            if (i2 == i1)
                return;

            for (var i = 0; i < array.Count(); i++) {
                if (array[i] == i2) {
                    array[i] = i1;
                }
            }

            Count--;
        }

        public int Count { get; private set; }
    }
}