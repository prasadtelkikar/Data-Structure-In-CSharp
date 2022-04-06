using System;
using System.Collections.Generic;

namespace Stack_Problems
{
    internal class Stack_Using_LinkedList
    {
        private Node top = null;

        private void Push(int data)
        {
            var newNode = CreateNewNode(data);
            if(top == null)
            {
                top = newNode;
                return;
            }
            newNode.NextNode = top;
            top = newNode;
        }

        private void PushMultiple(IList<int> elements)
        {
            foreach (int element in elements)
                this.Push(element);
        }

        private int Pop()
        {
            if (IsStackEmpty())
                return -1;
            var poppedValue = top.Data;
            top = top.NextNode;
            return poppedValue;
        }

        private void Display()
        {
            Console.WriteLine("NULL");
            Console.WriteLine("----");
            for (Node currentNode = top; currentNode != null; currentNode=currentNode.NextNode)
            {
                Console.WriteLine(currentNode.Data);
                Console.WriteLine("----");
            }
        }

        private Node CreateNewNode(int data) => new Node(data);

        private bool IsStackEmpty() => top == null;

        private int Top() => top.Data;

        static void Main(string[] args)
        {
            var data = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Stack_Using_LinkedList stack = new Stack_Using_LinkedList();
            stack.PushMultiple(data);
            stack.Display();

            int firstPoppedData = stack.Pop();
            int secondPoppedData = stack.Pop();
            Console.WriteLine($"{Environment.NewLine}First Popped Element = {firstPoppedData}");
            Console.WriteLine($"Second Popped Element = {secondPoppedData}");

            Console.WriteLine($"Display after two Pop operations{Environment.NewLine}");
            stack.Display();

        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data) { this.Data = data; this.NextNode = null; }
        }
    }
}
