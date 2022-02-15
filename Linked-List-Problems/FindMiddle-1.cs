using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindMiddle_1
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
        private int GetLength()
        {
            var count = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode, count++) ;
            return count;
        }

        private Node FindMiddle()
        {
            var currentNode = head;
            int length = GetLength();
            for (int i = 0; i < length / 2; i++)
                currentNode = currentNode.NextNode;

            return currentNode;
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            FindMiddle_1 findMiddle1 = new FindMiddle_1();
            findMiddle1.InsertMultiple(elements);

            findMiddle1.Display();
            var result = findMiddle1.FindMiddle();

            Console.WriteLine($"{Environment.NewLine}Middle Node Data: {result.Data}");

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
