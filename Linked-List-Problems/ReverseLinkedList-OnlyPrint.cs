using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReverseLinkedList_OnlyPrint
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head != null)
                newNode.NextNode = head;
            head = newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (int element in elements)
                InsertAtBeginning(element);

        }

        private void Display()
        {
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
            {
                if (currentNode.NextNode == null)
                    Console.WriteLine($"{currentNode.Data} -> Null");
                else
                    Console.Write($"{currentNode.Data} -> ");
            }
        }

        //Using Stack
        private void DisplayReverse()
        {
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = head;
            while(currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.NextNode;
            }
            while(stack.Count > 0)
            {
                if (stack.Count == 0)
                    Console.WriteLine($"{stack.Pop().Data} -> null");
                else
                    Console.Write($"{stack.Pop().Data} -> ");
            }
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ReverseLinkedList_OnlyPrint reverseListOnlyPrint = new ReverseLinkedList_OnlyPrint();
            reverseListOnlyPrint.InsertMultiple(list);
            
            Console.WriteLine("Before Reverse Print");
            reverseListOnlyPrint.Display();

            Console.WriteLine("After Reverse Print");
            reverseListOnlyPrint.DisplayReverse();
        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
