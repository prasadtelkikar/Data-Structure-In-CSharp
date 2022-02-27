using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CircularList_Split
    {
        private Node head = null;
        private int length = 0;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                newNode.NextNode = head;

            }
            else
            {
                var previousNode = head;
                while (previousNode.NextNode != head)
                    previousNode = previousNode.NextNode;

                newNode.NextNode = head;
                previousNode.NextNode = newNode;

                head = newNode;
            }
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private void Display(Node head)
        {
            var currentNode = head;
            if (head == null)
            {
                Console.WriteLine("Linked list is empty");
                return;
            }
            do
            {
                Console.Write(currentNode.NextNode != head ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL\n");
                currentNode = currentNode.NextNode;
            }while(currentNode != head);
        }

        private void SplitList()
        {
            Node fastPointer = head;
            Node slowPointer = head;

            //Floyd cyclic algorithm.
            while(fastPointer.NextNode != head && fastPointer.NextNode.NextNode != head)
            {
                fastPointer = fastPointer.NextNode.NextNode;
                slowPointer = slowPointer.NextNode;
            }

            //If linked list is even, then move fast pointer to next pointer.
            if (fastPointer.NextNode.NextNode == head)
                fastPointer = fastPointer.NextNode;

            Node headOne = head;
            Node headTwo = head;

            if(head.NextNode != head)
                headTwo = slowPointer.NextNode;

            fastPointer.NextNode= slowPointer.NextNode;
            slowPointer.NextNode= headOne;

            Console.WriteLine("\nFirst Split: ");
            Display(headOne);

            Console.WriteLine("\nSecond Split: ");
            Display(headTwo);
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var elements = new List<int> { 6, 5, 4, 3, 2, 1 };
            CircularList_Split split = new CircularList_Split();
            split.InsertMultiple(elements);

            split.SplitList();
            Console.ReadKey();
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
