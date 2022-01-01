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

        //0 based indexing
        public void InsertAtLocation(int data, int index)
        {
            var newNode = CreateNewNode(data);
            var currentNode = head;
            Node previousNode = null;
            var currentIndex = 0;
            if(index == 0)
            {
                newNode.next = currentNode;
                head = newNode;
                this.length++;
            }
            else
            {
                //Traverse the list until the position where we want to insert
                while(currentNode != null && currentIndex < index)
                {
                    currentIndex++;
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }

                //Insert new node
                previousNode.next = newNode;
                newNode.next = currentNode;
                this.length++;
            }

        }

        private void DeleteAtBeginning()
        {
            var currentNode = head;
            if (head == null)
                Console.WriteLine("Linked List is already empty, can't delete node anymore");
            else
            {
                head = currentNode.next;
                currentNode.next = null;
                this.length--;
            }
        }

        private void DeleteAtEnd()
        {
            var currentNode = head;
            Node previousNode = null;
            if (currentNode == null)
                Console.WriteLine("Linked List is already empty, can't delete node anymore");
            else
            {
                while(currentNode.next != null)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }
                previousNode.next = null;
                currentNode = null;
                this.length--;
            }

        }

        //0 based indexing
        private void DeleteAtLocation(int index)
        {
            var currentNode = head;
            Node previousNode = null;
            var currentIndex = 0;

            if (currentNode == null)
            {
                Console.WriteLine("Linked list is already empty, can't delete node anymore");
                return;
            }
            else
            {
                while (currentNode != null && currentIndex < index)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                    currentIndex++;
                }

                if (currentNode == null)
                    Console.WriteLine("Wrong index entered, can't delete");
                else
                {
                    previousNode.next = currentNode.next;
                    currentNode = null;
                    this.length--;
                }
            }
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
                        Console.WriteLine($"{currentNode.data} -> NULL");
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

            //Insert
            singlyLinkedList.InsertMultiNodeAtBeginning(beginning_data);
            singlyLinkedList.InsertMultiNodeAtEnd(end_data);
            singlyLinkedList.InsertAtLocation(1000, 6);

            //Delete
            singlyLinkedList.DeleteAtBeginning();
            singlyLinkedList.DeleteAtEnd();
            singlyLinkedList.DeleteAtLocation(5);

            //Utilities
            singlyLinkedList.Display();
            Console.WriteLine($"{Environment.NewLine}Length of Given LinkedList = {singlyLinkedList.GetLength()}");
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
