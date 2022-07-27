using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class TopologicalSort
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

            var result = FindTopologicalSort(graph.AdjacencyList);
            Console.WriteLine(String.Join(", ", result));
        }


        public static string[] FindTopologicalSort(List<Vertex> adjacencyVertex)
        {
            List<string> tSorted = new List<string>();
            Dictionary<string, int> inDegree = new Dictionary<string, int>();

            foreach (Vertex vertex in adjacencyVertex)
            {
                if (!inDegree.ContainsKey(vertex.Name))
                    inDegree.Add(vertex.Name, 0);

                foreach (string edge in vertex.Edges)
                {
                    if (inDegree.ContainsKey(edge))
                        inDegree[edge]++;
                    else
                        inDegree.Add(edge, 1);
                }

            }
            Queue<string> queue = new Queue<string>();
            foreach(var kvp in inDegree)
            {
                if(kvp.Value == 0)
                    queue.Enqueue(kvp.Key);
            }

            while(queue.Count > 0)
            {
                string dequeue = queue.Dequeue();
                tSorted.Add(dequeue);

                var edges = adjacencyVertex.Find(x => x.Name == dequeue)?.Edges;

                foreach(var edge in edges)
                {
                    if(inDegree.ContainsKey(edge) && inDegree[edge] > 0)
                    {
                        inDegree[edge]--;

                        if(inDegree[edge] == 0)
                            queue.Enqueue(edge);
                    }
                }    
            }
            return tSorted.ToArray();

        }
    }
}
