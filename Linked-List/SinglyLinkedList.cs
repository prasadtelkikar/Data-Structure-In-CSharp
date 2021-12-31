using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List
{
    public class SinglyLinkedList
    {
        private Node head = null;
        private int length = 0;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
                head = newNode;
            else
            {
                newNode.next = head;
                head = newNode;
            }
            this.length++;
        }

        private void InsertAtEnd(int data)
        {
            var currentNode = head;
            var newNode = CreateNewNode(data);
            if (currentNode == null)
                head = newNode;
            else
            {
                while(currentNode.next != null)
                    currentNode = currentNode.next; 
                currentNode.next = newNode;
            }
            this.length++;
        }
        private void InsertMultiNodeAtBeginning(IList<int> data)
        {
            foreach (var item in data)
                InsertAtBeginning(item);
        }

        private void InsertMultiNodeAtEnd(IList<int> data)
        {
            foreach (var item in data)
                InsertAtEnd(item);
        }

        public void InsertAtLocation(int index)
        {

        }
        private void Display()
        {
            var currentNode = head;
            if (head == null)
                Console.WriteLine("Empty Linked List");
            else
            {
                while(currentNode != null)
                {
                    if(currentNode.next != null)
                        Console.Write($"{currentNode.data} -> ");
                    else
                        Console.Write($"{currentNode.data} -> NULL");
                    currentNode = currentNode.next;
                }
            }
        }

        private int GetLength()
        {
            return this.length;
        }

        private int GetLengthByNode()
        {
            var currentNode = head;
            var count = 0;

            while(currentNode != null)
            {
                count++;
                currentNode = currentNode.next;
            }
            return count;
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var beginning_data = new List<int>() { 6, 5, 4, 3, 2, 1};
            var end_data = new List<int>() { 10, 20, 30, 40, 50, 60 };
            SinglyLinkedList singlyLinkedList = new SinglyLinkedList();
            singlyLinkedList.InsertMultiNodeAtBeginning(beginning_data);
            singlyLinkedList.InsertMultiNodeAtEnd(end_data);
            singlyLinkedList.Display();
            Console.WriteLine($"Length of Given LinkedList = {singlyLinkedList.GetLength()}");
            Console.WriteLine($"Length of Given LinkedList = {singlyLinkedList.GetLengthByNode()}");
        }
        private class Node
        {
            public int data = 0;
            public Node next = null;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        }
    }
}
