using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class SquareRoot
    {
        private Node head = null;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            newNode.NextNode = head;
            head = newNode;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }
        private void Display()
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);

        private Node SquareRootListByIndex()
        {
            Node sqRootNode = null;
            int i = 1, j = 1;
            for(Node currentNode = head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if(i == j * j)
                {
                    if (sqRootNode == null)
                        sqRootNode = head;
                    else
                        sqRootNode = sqRootNode.NextNode;
                    j++;
                }
                i++;
            }
            return sqRootNode;
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            SquareRoot squareRoot = new SquareRoot();
            squareRoot.InsertMultiple(elements);

            squareRoot.Display();

            var result = squareRoot.SquareRootListByIndex();
            Console.WriteLine(result.Data);

        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
