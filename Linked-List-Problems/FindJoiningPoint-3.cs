using System;
using System.Collections.Generic;

namespace Linked_List_Problems
{
    public class FindJoiningPoint_3
    {
        private Node firstHead = null;
        private Node secondHead = null;
        private void InsertAtBeginning(Node head, int data)
        {
            var newNode = CreateNewNode(data);
            if (head != null)
                newNode.NextNode = head;
            head = newNode;
        }
        private void InsertMultiple(IList<int> elements, bool addToFirst = true)
        {
            foreach (var element in elements)
            {
                var newNode = CreateNewNode(element);
                if (addToFirst)
                {
                    if (firstHead != null)
                        newNode.NextNode = firstHead;
                    firstHead = newNode;
                }
                else
                {
                    if (secondHead != null)
                        newNode.NextNode = secondHead;
                    secondHead = newNode;
                }
            }
        }
        private int? FindCommonPoint()
        {
            Stack<Node> firstListStack = new Stack<Node>();
            Stack<Node> secondListStack = new Stack<Node>();
            for (Node currentNode = firstHead; currentNode != null; currentNode=currentNode.NextNode)
                firstListStack.Push(currentNode);
            for (Node currentNode = secondHead; currentNode != null; currentNode=currentNode.NextNode)
                secondListStack.Push(currentNode);

            int? temp = null;
            while (true)
            {
                Node firstListTop = firstListStack.Pop();
                Node secondListTop = secondListStack.Pop();
                if (firstListTop != secondListTop && firstListTop.Data != secondListTop.Data)
                    return temp;
                else
                    temp = firstListTop.Data;

                if (firstListTop == null || secondListTop == null)
                    return temp;
            }
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            FindJoiningPoint_3 findJoiningPoint_3 = new FindJoiningPoint_3();

            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            findJoiningPoint_3.InsertMultiple(firstLinkedListData);
            findJoiningPoint_3.InsertMultiple(secondLinkedListData, false);

            findJoiningPoint_3.secondHead.NextNode.NextNode.NextNode.NextNode.NextNode = findJoiningPoint_3.firstHead.NextNode.NextNode;
            int? result = findJoiningPoint_3.FindCommonPoint();
            Console.WriteLine(result != null ? $"Common point of both the lists are = {result}" : "Both  linked lists are parallel");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
