using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class IsThereLoop
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();
            string[] vertices = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            foreach (var vertex in vertices)
                graph.AddVertex(vertex);

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("B", "C");
            graph.AddEdge("B", "D");
            graph.AddEdge("C", "E");
            graph.AddEdge("D", "E");
            graph.AddEdge("D", "F");
            graph.AddEdge("G", "F");
            graph.AddEdge("G", "E");


            var result = FindLoopByTopologicalSort(graph.AdjacencyList);
            Console.WriteLine(result);
        }

        private static bool FindLoopByTopologicalSort(List<Vertex> adjacencyList)
        {
            int count = 0;
            Dictionary<string, int> inDegree = new Dictionary<string, int>();

            foreach (Vertex vertex in adjacencyList)
            {
                if (!inDegree.ContainsKey(vertex.Name))
                    inDegree.Add(vertex.Name, 0);

                foreach (var edge in vertex.Edges)
                {
                    if (inDegree.ContainsKey(edge))
                        inDegree[edge]++;
                    else
                        inDegree.Add(edge, 1);
                }
            }

            Queue<string> queue = new Queue<string>();
            foreach (var kvp in inDegree)
            {
                if(kvp.Value == 0)
                    queue.Enqueue(kvp.Key);
            }

            while(queue.Count > 0)
            {
                string current = queue.Dequeue();
                count++;
                foreach(var edge in adjacencyList.Find(x => x.Name == current).Edges)
                {
                    if(inDegree.ContainsKey(edge))
                        inDegree[edge]--;
                    if (inDegree[edge] == 0)
                        queue.Enqueue(edge);
                }       
            }
            return !(count == inDegree.Count);
        }
    }
}
