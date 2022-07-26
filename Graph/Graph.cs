using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Graph
    {
        public List<Vertex> AdjacencyList { get; set; }
        public Graph()
        {
            AdjacencyList = new List<Vertex>();
        }

        public bool AddVertex(string newVertex)
        {
            if (this.AdjacencyList.Find(x => x.Name == newVertex) != null)
                return true;

            this.AdjacencyList.Add(new Vertex(newVertex));
            return true;
        }

        public bool AddEdge(string vertex1, string vertex2)
        {
            this.AdjacencyList.Find(x => x.Name == vertex1).Edges.Add(vertex2);
            this.AdjacencyList.Find(x => x.Name == vertex2).Edges.Add(vertex1);

            return true;

        }

        public bool RemoveEdge(string vertex1, string vertex2)
        {
            this.AdjacencyList.Find(x => x.Name == vertex1).Edges.Remove(vertex2);
            this.AdjacencyList.Find(x => x.Name == vertex2).Edges.Remove(vertex1);

            return true;
        }


        ///DSF recursive
        public List<string> DSFRecursive(string startVertex)
        {
            Vertex start = AdjacencyList.Find(x => x.Name == startVertex);
            if(start == null)
                return null;

            List<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            DSF(start, result, visited);
            return result;
        }

        private void DSF(Vertex start, List<string> result, HashSet<string> visited)
        {
            if (start == null || visited.Contains(start.Name))
                return;

            result.Add(start.Name);
            visited.Add(start.Name);

            foreach(string neighbor in start.Edges)
            {
                if(!visited.Contains(neighbor))
                {
                    Vertex neighoringVertex = AdjacencyList.Find(x => x.Name == neighbor);
                    DSF(neighoringVertex, result, visited);
                }
            }
        }

        public List<string> DSFItearative(string start)
        {
            Vertex startingVertex = AdjacencyList.Find(x => x.Name == start);
            if (startingVertex == null)
                return null;

            Stack<Vertex> stack = new Stack<Vertex>();
            HashSet<string> visited = new HashSet<string>();
            List<string> result = new List<string>();
            
            stack.Push(startingVertex);
            while(stack.Count > 0)
            {
                var topVertex = stack.Pop();

                if (!visited.Contains(topVertex.Name))
                    continue;

                result.Add(topVertex.Name);
                visited.Add(topVertex.Name);

                foreach (var neighbor in topVertex.Edges)
                {
                    if(!visited.Contains(neighbor))
                    {
                        stack.Push(AdjacencyList.Find(x => x.Name == neighbor));
                    }
                }
            }

            return result;
        }

        public List<string> BFSTraversal(string start)
        {
            Vertex startingVertex = AdjacencyList.Find(x => x.Name == start);

            if (startingVertex == null)
                return null;

            Queue<Vertex> queue = new Queue<Vertex>();
            List<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(startingVertex);
            
            while(queue.Count > 0)
            {
                var deQueuedElement = queue.Dequeue();
                if(!visited.Contains(deQueuedElement.Name))
                    continue ;

                result.Add(deQueuedElement.Name);
                visited.Add(deQueuedElement.Name);

                foreach (string neighbor in deQueuedElement.Edges)
                {
                    if(!visited.Contains(neighbor))
                    {
                        queue.Enqueue(AdjacencyList.Find(x => x.Name == neighbor));
                    }
                }

            }

            return result;
        }
    }
}
