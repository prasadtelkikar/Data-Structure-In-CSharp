using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List
{
    public class DoublyLinkedList
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
                head.previousNode = newNode;
                newNode.nextNode = head;
                newNode.previousNode = null;
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
                var currentNode = head;
                while(currentNode.nextNode != null)
                    currentNode = currentNode.nextNode;
                currentNode.nextNode = newNode;
                newNode.previousNode = currentNode;
            }
            this.length++;
        }

        //0 Based indexing
        private void InsertAtLocation(int data, int index)
        {
            var newNode = CreateNewNode(data);
            var currentNode = head;
            var currentIndex = 0;
            if(index == 0)
            {
                newNode.nextNode = currentNode;
                currentNode.previousNode = newNode;
                head = newNode;
                this.length++;
            }
            else
            {
                while(currentNode != null && currentIndex < index)
                {
                    currentNode = currentNode.nextNode;
                    currentIndex++;
                }

                newNode.nextNode = currentNode.nextNode;
                newNode.previousNode = currentNode;
                if(currentNode.nextNode != null)    
                    currentNode.nextNode.previousNode = newNode;
                currentNode.nextNode = newNode;
                this.length++;
            }
        }
        private void InsertMultiNodeAtBeginning(IList<int> data)
        {
            foreach (var item in data)
                InsertAtBeginning(item);
        }

        private void DeleteAtBeginning()
        {
            var currentNode = head;
            if (head == null)
                Console.WriteLine("Empty Linked List, can't perform delete operation");
            else
            {
                head = currentNode.nextNode;
                currentNode = null;
                this.length--;
            }
        }

        private void DeleteAtEnd()
        {
            var currentNode = head;
            if (head == null)
                Console.WriteLine("Empty linked list, can't perform delete operation");
            else
            {
                while(currentNode.nextNode != null)
                    currentNode = currentNode.nextNode;

                currentNode.previousNode.nextNode = null;
                currentNode = null;
                this.length--;
            }    
        }

        private void DeleteAtLocation(int position)
        {
            var currentIndex = 0;
            var currentNode = head; 
            if (head == null)
                Console.WriteLine("Empty linked list, can't perform delete operation");
            else if(position == 0)
            {
                head = head.nextNode;
                this.length--;
            }
            else
            {
                while (currentIndex < position && currentNode.nextNode != null)
                {
                    currentIndex++;
                    currentNode = currentNode.nextNode;
                }

                var previousNode = currentNode.previousNode;
                if (previousNode != null)
                    previousNode.nextNode = currentNode.nextNode;
                if(currentNode.nextNode!=null)
                    currentNode.nextNode.previousNode = previousNode;

                currentNode = null;
                this.length--;
            }
        }
        
        private void InsertMultiNodeAtEnd(IList<int> data)
        {
            foreach (var item in data)
                InsertAtEnd(item);
        }
        private int GetLength() => this.length;

        private int GetLengthByNode()
        {
            var count = 0;
            for (var i = head; i != null; i = i.nextNode, count++) ;
            return count;
        }

        private void Display()
        {
            for (var i = head; i != null; i = i.nextNode)
            {
                if (i.nextNode != null)
                    Console.Write($"{i.data} -> ");
                else
                    Console.WriteLine($"{i.data} -> NULL");
            }
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var beginning_data = new List<int>() { 6, 5, 4, 3, 2, 1 };
            var end_data = new List<int>() { 10, 20, 30, 40, 50, 60 };

            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
            
            //Insert
            doublyLinkedList.InsertMultiNodeAtBeginning(beginning_data);
            doublyLinkedList.InsertMultiNodeAtEnd(end_data);
            doublyLinkedList.InsertAtLocation(100, 6);

            //Delete
            doublyLinkedList.DeleteAtBeginning();
            doublyLinkedList.DeleteAtEnd();
            doublyLinkedList.DeleteAtLocation(6);

            //Utilities
            doublyLinkedList.Display();
            Console.WriteLine($"{Environment.NewLine}Length of Given Doubly linked list = {doublyLinkedList.GetLength()}");
            Console.WriteLine($"Length of Given Doubly linked list = {doublyLinkedList.GetLengthByNode()}");

        }
        private class Node
        {
            public int data = 0;
            public Node previousNode = null;
            public Node nextNode= null;

            public Node(int data)
            {
                this.data = data;
                this.previousNode = null;
                this.nextNode = null;
            }
        }
    }
}
