using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class EvenOdd_1
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
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }

        private bool IsLListEven() => this.length % 2 == 0;

        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            EvenOdd_1 evenOdd1 = new EvenOdd_1();
            evenOdd1.InsertMultiple(elements);

            evenOdd1.Display();
            Console.WriteLine(evenOdd1.IsLListEven() ? "Given Linked list is Even" : "Given Linked list is Odd");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }

 }
