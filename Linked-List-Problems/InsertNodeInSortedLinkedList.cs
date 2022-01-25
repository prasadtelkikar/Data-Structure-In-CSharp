using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class InsertNodeInSortedLinkedList
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head == null)
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

        private void InsertInSortedLinkedList(int  data)
        {
            var newNode = CreateNewNode(data);
            var currentNode = head;
            var previousNode = head;
            if (currentNode == null)
            {
                head = newNode;
                this.length++;
                return ;
            }
            while(currentNode != null && currentNode.Data < data)
            {
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            newNode.NextNode = currentNode;
            previousNode.NextNode = newNode;
            this.length++;
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
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 7, 6, 5, 4, 2, 1 };
            var missingNumber = 3;

            InsertNodeInSortedLinkedList sortedList = new InsertNodeInSortedLinkedList();
            sortedList.InsertMultiple(elements);

            Console.WriteLine("Before new Insert");
            sortedList.Display();

            sortedList.InsertInSortedLinkedList(missingNumber);

            Console.WriteLine("After inserting a node");
            sortedList.Display();
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) { this.Data = data; }
        }
    }
}
