using System;
using System.Collections.Generic;

namespace Linked_List_Problems
{
    public class StackUsingLinkedList
    {
        private int length = 0;
        private Node top = null;

        private void Push(int data)
        {
            var newNode = CreateNewNode(data);
            if (top!=null)
                newNode.NextNode = top;
            top = newNode;
            this.length++;
        }

        private int Pop()
        {
            if (top==null)
            {
                Console.WriteLine("Stack is empty, can't pop anymore");
                return -1;
            }
            var popData = top.Data;
            top = top.NextNode;
            this.length--;
            return popData;
        }


        private void PushMultiple(IList<int> data)
        {
            foreach (var item in data)
                Push(item);
        }

        private void PopMultiple(int popCount)
        {
            for (int i = 0; i < popCount; i++)
            {
                var topData = Pop();
                Console.WriteLine($"Pop top = {topData}");
            }
        }

        private int Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            return top.Data;
        }

        private void Display()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            //revere the linked-list
            Node currentNode = top;
            Node previousNode = null, nextNode = null;

            while(currentNode != null)
            {
                nextNode = currentNode.NextNode;
                currentNode.NextNode = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }

            //Print
            
            while(previousNode != null)
            {
                if (previousNode.NextNode == null)
                    Console.WriteLine($"{ previousNode.Data} -> (TOP)NULL");
                else
                    Console.Write($"{previousNode.Data} -> ");

                previousNode = previousNode.NextNode;
            }
        }
        private int GetLength(bool canUseVariable = true)
        {
            if (canUseVariable)
                return this.length;
            else
            {
                var currentNode = top;
                var stackLength = 0;
                while (currentNode !=null)
                {
                    currentNode = currentNode.NextNode;
                    stackLength++;
                }
                return stackLength;
            }
        }
        
        private Node CreateNewNode(int data)
        {
            return new Node(data);
        }

        public static void Main(string[] args)
        {
            IList<int> list = new List<int>() { 1, 2, 3, 4, 5, 6};
            StackUsingLinkedList stackUsingLinkedList = new StackUsingLinkedList();

            stackUsingLinkedList.PushMultiple(list);
            stackUsingLinkedList.PopMultiple(2);

            Console.WriteLine($"Test single Pop method = {stackUsingLinkedList.Pop()}");
            Console.WriteLine($"Peek of the Stack = {stackUsingLinkedList.Peek()}");

            stackUsingLinkedList.Display();
            Console.WriteLine($"Length of the stack = {stackUsingLinkedList.GetLength()}");
            Console.WriteLine($"Length of the stack = {stackUsingLinkedList.GetLength(canUseVariable:false)}");
        }

        private class Node
        {
            public int Data { get; set; } = 0;
            public Node NextNode { get; set; } = null;

            public Node(int data)
            {
                this.Data = data;
                this.NextNode = null;
            }

        }

    }
}
