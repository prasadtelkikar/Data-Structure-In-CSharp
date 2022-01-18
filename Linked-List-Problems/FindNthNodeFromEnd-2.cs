using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindNthNodeFromEnd_2
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

        private int FindNthNodeFromEnd(int nthNodeFromEndIndex)
        {
            Node currentNode = head;
            Node nthNodeFromEnd = head;
            for(int i = 0;i < nthNodeFromEndIndex; i++)
                currentNode = currentNode.NextNode;
            while(currentNode!= null)
            {
                currentNode = currentNode.NextNode;
                nthNodeFromEnd = nthNodeFromEnd.NextNode;
            }

            return nthNodeFromEnd?.Data ?? -1;
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Enter node index from end");
            var nthNodeIndexFromEnd = int.Parse(Console.ReadLine());

            FindNthNodeFromEnd_2 findNthNodeFromEnd = new FindNthNodeFromEnd_2();
            findNthNodeFromEnd.InsertMultiple(elements);

            findNthNodeFromEnd.Display();
            var result = findNthNodeFromEnd.FindNthNodeFromEnd(nthNodeIndexFromEnd);

            //-1 denotes not in the range
            Console.WriteLine($"{nthNodeIndexFromEnd} Node from End = {result}.");
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
