using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindNthNodeFromEnd_1
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

        //Alternate way(efficient) way is to use length variable
        private int GetLength()
        {
            var count = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode, count++) ;
            return count;
        }

        private Node CreateNewNode(int data) => new Node(data);

        private void Display()
        {
            var index = 0;
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode, index++)
            {
                if (currentNode.NextNode != null)
                    Console.Write($"Data:{currentNode.Data} Index:{(index)} -> ");
                else
                    Console.WriteLine($"Data:{currentNode.Data} Index:{(index)} -> NULL");
            }
        }

        private int FindNthNodeFromEnd(int nthNodeFromEnd)
        {
            Dictionary<int, Node> nodeWithIndex = new Dictionary<int, Node>();
            int length = 0; //We can use nodeWithIndex.Count();

            for (Node currentNode = head; currentNode != null; currentNode = currentNode.NextNode, length++)
                nodeWithIndex.Add(length, currentNode);

            var nthNodeFromFirst = length - nthNodeFromEnd;

            //Return -1 if the range is out of bound
            if (nodeWithIndex.ContainsKey(nthNodeFromFirst))
                return nodeWithIndex[nthNodeFromFirst].Data;
            else
                return -1;

        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Enter node index to be removed");
            var nodeToBeRemoved = int.Parse(Console.ReadLine());

            FindNthNodeFromEnd_1 findNthNodeFromEnd = new FindNthNodeFromEnd_1();
            findNthNodeFromEnd.InsertMultiple(elements);

            findNthNodeFromEnd.Display();
            var result = findNthNodeFromEnd.FindNthNodeFromEnd(nodeToBeRemoved);

            //-1 denotes not in the range
            Console.WriteLine($"Removed {nodeToBeRemoved} Node from End = {result}.");
        }
        private class Node
        {

            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data)
            {
                this.Data= data;
                this.NextNode = null;
            }

        }
    }
}
