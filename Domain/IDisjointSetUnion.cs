using System.Collections.Generic;

namespace Domain {
    public interface IDisjointSetUnion<T> {
        T Find(T item);
        void Union(T item1, T item2);
    }
}