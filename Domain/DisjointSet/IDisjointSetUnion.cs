namespace Domain.DisjointSet {
    public interface IDisjointSetUnion<T> {
        T Find(T item);
        void Union(T item1, T item2);
        int Count { get; }
    }
}