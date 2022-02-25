using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class LinkedList_Sum
    {
        private Node head = null;
        private int length = 0;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                length++;
                return;
            }
            newNode.NextNode = head;
            length++;
            head = newNode;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private (int, int) Sum()
        {
            var firstLinkedListLength = Math.Floor(length/2d);
            var secondLinkedListLength = Math.Ceiling(length/2d);
            var firstNumber = 0;
            var secondNumber = 0;
            var currentNode = head;
            for (int i = 0; i < firstLinkedListLength; i++)
            {
                firstNumber = firstNumber * 10 + currentNode.Data;
                currentNode = currentNode.NextNode;
            }
            for (int i = 0; i < secondLinkedListLength; i++)
            {
                secondNumber = secondNumber * 10 + currentNode.Data;
                currentNode = currentNode.NextNode;
            }
            return (firstNumber, secondNumber);
        }
        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 6, 5, 4, 3, 2, 1};
            LinkedList_Sum linkedListSumObj = new LinkedList_Sum();
            linkedListSumObj.InsertMultiple(elements);

            Console.WriteLine("Actual Linked List:");
            linkedListSumObj.Display(linkedListSumObj.head);

            var result = linkedListSumObj.Sum();
            Console.WriteLine();
            Console.WriteLine($"Sum of first half = {result.Item1} \nSum of second half = {result.Item2} \nTotal Sum = {result.Item1 + result.Item2}");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
