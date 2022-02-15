using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    internal class FindMiddle_2
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                this.length++;
                return;
            }
            newNode.NextNode = head;
            head = newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
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
        private int GetLength()
        {
            var count = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode, count++) ;
            return count;
        }

        private Node FindMiddle()
        {
            Dictionary<int, Node> NodeWithIndex = new Dictionary<int, Node>();
            int index = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
            {
                NodeWithIndex.Add(index, currentNode);
                index++;
            }
            int middle = index / 2;
            return NodeWithIndex[middle];
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            FindMiddle_2 findMiddle2 = new FindMiddle_2();
            findMiddle2.InsertMultiple(elements);

            findMiddle2.Display();
            var result = findMiddle2.FindMiddle();

            Console.WriteLine($"{Environment.NewLine} Middle Node Data: {result.Data}");

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
