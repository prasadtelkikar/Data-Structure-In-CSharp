using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class AccessNode
    {
        private Node head = null;
        private int length = 0;
        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        private void InsertAtEnd(int data)
        {
            var currentNode = head;
            var newNode = CreateNewNode(data);
            if (currentNode == null)
            {
                head = newNode;
            }
            else
            {
                while (currentNode.NextNode != null)
                    currentNode = currentNode.NextNode;
                currentNode.NextNode = newNode;
            }
            nodes.Add(length, newNode);
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtEnd(element);
        }

        private void Display()
        {
            var index = 0;
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode, index++)
            {
                if (currentNode.NextNode != null)
                    Console.Write($"Data:{currentNode.Data} Index:{(index)} -> ");
                else
                    Console.WriteLine($"Data:{currentNode.Data} Index:{(index)} -> NULL");
            }
        }
        private Node CreateNewNode(int data) => new Node(data);

        private Node FindNthNode(int index)
        {
            return nodes.TryGetValue(index, out Node result) ? result : null;
        }
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            AccessNode accessNodeObj = new AccessNode();
            accessNodeObj.InsertMultiple(elements);

            accessNodeObj.Display();
            var result = accessNodeObj.FindNthNode(3); //Nth node from beginning. Expected output is 4

            if (result == null)
                Console.WriteLine("Node at given index not found");
            else
                Console.WriteLine($"{Environment.NewLine} 3rd Node from the beginning is : {result.Data}");

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
