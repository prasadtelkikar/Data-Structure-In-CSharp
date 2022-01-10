using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindNthNodeFromEnd
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
            newNode.NexNode = head;
            head = newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        //Alternate way(efficient) way is to use length variable
        private int GetLength()
        {
            var count = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NexNode, count++) ;
            return count;
        }

        private int FindNthNodeDataFromEnd(int nthFromEnd)
        {
            var length = GetLength();
            var nthFromFirst = length - nthFromEnd;
            var currentNode = head;
            if (nthFromEnd > length)
            {
                Console.WriteLine("Fewer nodes are available than given index");
                return -1;
            }
            for (int currnetIndex = 0; currnetIndex < nthFromFirst; currnetIndex++)
                currentNode = currentNode.NexNode;
            return currentNode.Data;
        }
        private Node CreateNewNode(int data) => new Node(data);

        private void Display()
        {
            var index = 0;
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NexNode, index++)
            {
                if (currentNode.NexNode != null)
                    Console.Write($"Data:{currentNode.Data} Index:{(index)} -> ");
                else
                    Console.WriteLine($"Data:{currentNode.Data} Index:{(index)} -> NULL");
            }
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Enter node index to be removed");
            var nodeToBeRemoved = int.Parse(Console.ReadLine());
            
            FindNthNodeFromEnd findNthNodeFromEnd = new FindNthNodeFromEnd();
            findNthNodeFromEnd.InsertMultiple(elements);

            findNthNodeFromEnd.Display();
            var result = findNthNodeFromEnd.FindNthNodeDataFromEnd(nodeToBeRemoved);

            //-1 denotes not in the range
            Console.WriteLine($"Removed {nodeToBeRemoved} Node from End = {result}.");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NexNode { get; set; }

            public Node(int data)
            {
                this.Data = data;
                this.NexNode = null;
            }
        }
    }
}
