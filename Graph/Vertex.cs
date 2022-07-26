using System;
using System.Collections.Generic;

namespace Graph
{
    public class Vertex
    {
        public string Name { get; set; }
        public List<string> Edges { get; set; }

        public Vertex(string name)
        {
            this.Name = name;
            this.Edges = new List<string>();
        }
    }
}
