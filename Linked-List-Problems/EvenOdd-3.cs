using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class EvenOdd_3
    {
        private Node head = null;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            newNode.NextNode = head;
            head = newNode;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }
        private void Display()
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }

        private bool IsEven()
        {
            var currentNode = head;
            while (currentNode != null && currentNode.NextNode != null)
                currentNode = currentNode.NextNode.NextNode;

            return currentNode == null;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            EvenOdd_3 evenOdd3 = new EvenOdd_3();
            evenOdd3.InsertMultiple(elements);

            evenOdd3.Display();
            Console.WriteLine(evenOdd3.IsEven() ? "Given Linked list is Even" : "Given Linked list is Odd");

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
