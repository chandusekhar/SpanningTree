using System;
using System.Collections;

namespace Domain {
    public class MyHashSet {
        private readonly BitArray matrix;
        private readonly int size;

        public MyHashSet(int size) {
            this.size = size;
            matrix = new BitArray(this.size*this.size);
        }

        public void Add(Tuple<int, int> value) {
            var x = value.Item1;
            var y = value.Item2;

            matrix[y*size + x] = true;
            matrix[x*size + y] = true;
        }

        public bool Contains(Tuple<int, int> value) {
            var x = value.Item1;
            var y = value.Item2;

            return (matrix[y*size + x]);
        }
    }
}