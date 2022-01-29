using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReverseLinkedList_OnlyPrint_Reverse
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head != null)
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
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
            {
                if (currentNode.NextNode == null)
                    Console.WriteLine($"{currentNode.Data} -> null");
                else
                    Console.Write($"{currentNode.Data} -> ");
            }
        }

        private void DisplayReverseRecursively(Node currentNode)
        {
            if (currentNode == null)
                return;
            DisplayReverseRecursively(currentNode.NextNode);
            Console.Write($"{currentNode.Data} -> ");
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var elements = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            ReverseLinkedList_OnlyPrint_Reverse reverseLinkedListPrint = new ReverseLinkedList_OnlyPrint_Reverse();

            reverseLinkedListPrint.InsertMultiple(elements);
            Console.WriteLine("Before Reverse");
            reverseLinkedListPrint.Display();

            Console.WriteLine("After Reverse");
            reverseLinkedListPrint.DisplayReverseRecursively(reverseLinkedListPrint.head);
            Console.Write("null"); //Just for beautification: To show null as an end of linked list
        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
