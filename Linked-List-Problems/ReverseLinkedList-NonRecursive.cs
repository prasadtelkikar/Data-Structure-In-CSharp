using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReverseLinkedList_NonRecursive
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
            newNode.NextData = head;
            head=newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private void Display(Node head)
        {
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextData)
            {
                if (currentNode.NextData == null)
                    Console.WriteLine($"{currentNode.Data} -> null");
                else
                    Console.Write($"{currentNode.Data} -> ");
            }
        }

        private Node ReverseLinkedList()
        {
            Node currentNode = this.head;
            Node previousNode = null;

            while(currentNode != null)
            {
                var nextOfCurrent = currentNode.NextData;
                currentNode.NextData = previousNode;
                previousNode = currentNode;
                currentNode = nextOfCurrent;
            }
            return previousNode;
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            ReverseLinkedList_NonRecursive reverseObj = new ReverseLinkedList_NonRecursive();

            reverseObj.InsertMultiple(elements);
            Console.WriteLine("Before Reverse");
            reverseObj.Display(reverseObj.head);

            var reversedList = reverseObj.ReverseLinkedList();
            Console.WriteLine("After Reverse");
            reverseObj.Display(reversedList);
        }
        private Node CreateNewNode(int data) => new Node(data);
        private class Node
        {
            public int Data { get; set; }
            public Node NextData { get; set; }

            public Node(int data) { Data = data; }
        }
    }
}
