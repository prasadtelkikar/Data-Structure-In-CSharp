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
                var temp = head;
                while(temp.nextNode != null)
                    temp = temp.nextNode;
                temp.nextNode = newNode;
            }
            this.length++;
        }

        //0 Based indexing
        private void InsertAtLocation(int data, int index)
        {
            //TODO
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
