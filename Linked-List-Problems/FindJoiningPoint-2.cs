using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linked_List_Problems
{
    public class FindJoiningPoint_2
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

        //There is design problem: We can't write extension method to avoid this code duplication.
        //TODO: Research code refactoring for such senario: Insert multiple should work for multiple head nodes without code duplication
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

        private int GetLength(Node head)
        {
            int length = 0;
            for (Node currentNode = head; currentNode != null; currentNode = currentNode.NextNode, length++) ;
            return length;
        }
        private int FindCommonPoint()
        {
            int firstListLength = GetLength(firstHead);
            int secondListLength = GetLength(secondHead);
            Node smallestLinkedList = null;
            Node largestLinkedList = null;

            if(firstListLength > secondListLength)
            {
                smallestLinkedList = secondHead;
                largestLinkedList = firstHead;
            }
            else
            {
                smallestLinkedList = firstHead;
                largestLinkedList = secondHead;
            }

            List<Node> temp = new List<Node>();
            for (Node currentNode = smallestLinkedList; currentNode != null; currentNode = currentNode.NextNode)
                temp.Add(currentNode);

            for (Node currentNode = largestLinkedList; currentNode != null; currentNode=currentNode.NextNode)
            {
                if (temp.Any(x => x == currentNode && x.Data == currentNode.Data))
                    return currentNode.Data;
            }

            return -1;
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            FindJoiningPoint_2 findJoiningPoint_2 = new FindJoiningPoint_2();
            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            findJoiningPoint_2.InsertMultiple(firstLinkedListData);
            findJoiningPoint_2.InsertMultiple(secondLinkedListData, false);

            findJoiningPoint_2.secondHead.NextNode.NextNode.NextNode.NextNode.NextNode = findJoiningPoint_2.firstHead.NextNode.NextNode;
            int result = findJoiningPoint_2.FindCommonPoint();
            Console.WriteLine($"Common point of both the lists are = {result}");

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }

    }
}
