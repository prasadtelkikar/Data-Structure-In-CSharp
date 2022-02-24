using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReversePair_Recursively
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
        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }

        private Node ReversePairRecursively(Node head)
        {
            if (head == null || head.NextNode == null)
                return head;
            else
            {
                var temp = head.NextNode;
                head.NextNode = temp.NextNode;
                temp.NextNode = head;
                head = temp;

                head.NextNode.NextNode = ReversePairRecursively(head.NextNode.NextNode);
                return head;
            }

        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            ReversePair_Recursively reverseRecursively = new ReversePair_Recursively();
            reverseRecursively.InsertMultiple(elements);

            reverseRecursively.Display(reverseRecursively.head);
            var result = reverseRecursively.ReversePairRecursively(reverseRecursively.head);
            Console.WriteLine("After performing Reverse Pair");

            reverseRecursively.Display(result);
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }

    }
}
