using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReversePair_SwapData_Recursively
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
        private Node CreateNewNode(int data) => new Node(data);

        private void ReversePairData(Node head)
        {
            //Exit condition
            if (head == null || head.NextNode == null)
                return;

            //Swap data between two adjacent nodes
            int temp = head.Data;
            head.Data = head.NextNode.Data;
            head.NextNode.Data = temp;

            //Call Same method recursively to process next pair
            ReversePairData(head.NextNode.NextNode);
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            ReversePair_SwapData_Recursively swapData = new ReversePair_SwapData_Recursively();
            swapData.InsertMultiple(elements);

            Console.WriteLine("Actual Linked List:");
            swapData.Display(swapData.head);

            Console.WriteLine("Processed Linked List");
            swapData.ReversePairData(swapData.head);
            swapData.Display(swapData.head);

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
