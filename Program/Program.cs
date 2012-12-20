using System;
using Domain;

namespace Program {
    internal static class Program {
        private static void Main() {
            var graph = GraphGenerator.GenerateFromFile("PA2Q1data.txt");
            Console.WriteLine(Clustering.Cluster(graph, 4));
        }
    }
}