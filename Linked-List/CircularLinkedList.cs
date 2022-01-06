using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List
{
    public class CircularLinkedList
    {
        private Node head = null;
        private int length = 0;


        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head == null)
                head = newNode;
            else
            {
                var previousNode = head;
                while(previousNode.nextData != head)
                    previousNode = previousNode.nextData;

                newNode.nextData = head;
                previousNode.nextData = newNode;

                head = newNode;
            }
            this.length++;
        }
        private void InsertAtEnd(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
                head = newNode;
            else
            {
                var previousNode = head;
                do
                {
                    previousNode = previousNode.nextData;
                } while (previousNode.nextData != head);

                previousNode.nextData = newNode;
                newNode.nextData = head;
                this.length++;
            }
        }

        private void InsertMultipleNodeAtBeginning(IList<int> data)
        {
            foreach (var element in data)
                InsertAtBeginning(element);
        }

        private void InsertMultipleNodeAtEnd(IList<int> data)
        {
            foreach (var element in data)
                InsertAtEnd(element);
        }

        private void DeleteFromBeginning()
        {
            if (head == null)
            {
                Console.WriteLine("Empty circular linked list, can't delete anymore");
                return;
            }
            if (head.nextData == head)
            {
                head = null;
                this.length--;
                return;
            }
            else
            {
                var currentNode = head;
                var previousNode = head;
                do
                {
                    previousNode = previousNode.nextData;
                }while(previousNode.nextData != head);

                previousNode.nextData = currentNode.nextData;
                currentNode = currentNode.nextData;
                head = currentNode;
                currentNode = null;
                this.length--;
            }
        }
        private void DeleteFromEnd()
        {
            if (head == null)
            {
                Console.WriteLine("Empty circular linked list, can't delete anymore");
                return;
            }
            if (head.nextData == head)
            {
                head = null;
                this.length--;
                return;
            }
            else
            {
                var secondLastNode = head;
                do
                {
                    secondLastNode = secondLastNode.nextData;
                } while (secondLastNode.nextData.nextData != head);

                var lastNode = secondLastNode.nextData;
                secondLastNode.nextData = head;
                lastNode = null;
                this.length--;
            }
        }
        private void Display()
        {
            var currentNode = head;
            if(currentNode == null)
            {
                Console.WriteLine("Empty Circular linked list");
                return;
            }
            do
            {
                if (currentNode.nextData == head)
                    Console.WriteLine($"{currentNode.data} -> End of circular linked list");
                else
                    Console.Write($"{currentNode.data} ->");
                currentNode = currentNode.nextData; 
            }while(currentNode != head);
        }

        private int GetLength()
        {
            if (head == null)
                return 0;
            else
            {
                var currentNode = head;
                var count = 0;
                do
                {
                    count++;
                    currentNode = currentNode.nextData;
                } while (currentNode != head);

                return count;
            }
        }

        public static void Main(string[] args)
        {
            var inputData = new List<int>() { 1, 2, 3, 4, 5, 6 };

            CircularLinkedList circularLinkedList = new CircularLinkedList();
            //Insert
            circularLinkedList.InsertMultipleNodeAtBeginning(inputData);
            circularLinkedList.InsertMultipleNodeAtEnd(inputData);

            //Insert & Delete at a location will be same as Singly linked list

            //Delete
            circularLinkedList.DeleteFromBeginning();
            circularLinkedList.DeleteFromEnd();

            //Utilities
            circularLinkedList.Display();
            Console.WriteLine($"Length of circular linked list = {circularLinkedList.length}");
            Console.WriteLine($"Length of circular linked list = {circularLinkedList.GetLength()}");
        }
        //Create circular new node
        private Node CreateNewNode(int data)
        {
            var newNode = new Node(data);
            newNode.nextData = newNode;
            return newNode;
        }
        private class Node
        {
            public int data=0;
            public Node nextData = null;
            public Node(int data)
            {
                this.data = data;
            }
        }
    }
}
