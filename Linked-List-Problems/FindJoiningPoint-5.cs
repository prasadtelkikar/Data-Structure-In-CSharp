using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindJoiningPoint_5
    {
        private Node firstHead = null;
        private Node secondHead = null;
        private int firstLLLength = 0;
        private int secondLLLength = 0;

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
            Node largestLL = null;
            Node smallestLL = null;
            if (firstLLLength > secondLLLength)
            {
                largestLL = PreProcessForFindCommonPoint(secondLLLength, firstLLLength, firstHead);
                smallestLL = secondHead;
            }
            else
            {
                largestLL = PreProcessForFindCommonPoint(firstLLLength, secondLLLength, secondHead);
                smallestLL = firstHead;
            }

            while (largestLL != null || smallestLL != null)
            {
                if (largestLL == smallestLL)
                    return largestLL.Data;
                largestLL = largestLL.NextNode;
                smallestLL = smallestLL.NextNode;
            }
            return null;
        }
        private int GetLength(Node head)
        {
            int length = 0;
            for (Node currentNode = head; currentNode != null; currentNode=currentNode.NextNode, length++) ;
            return length;
        }
        private Node PreProcessForFindCommonPoint(int minLength, int maxLength, Node head)
        {
            var currentNode = head;
            int diffLength = maxLength - minLength;
            for (int i = 0;i< diffLength;i++)
                currentNode = currentNode.NextNode;
            return currentNode;
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            FindJoiningPoint_5 findJoiningPoint_5 = new FindJoiningPoint_5();

            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            findJoiningPoint_5.InsertMultiple(firstLinkedListData);
            findJoiningPoint_5.InsertMultiple(secondLinkedListData, false);

            findJoiningPoint_5.secondHead.NextNode.NextNode.NextNode.NextNode.NextNode = findJoiningPoint_5.firstHead.NextNode.NextNode;
            findJoiningPoint_5.firstLLLength =  findJoiningPoint_5.GetLength(findJoiningPoint_5.firstHead);
            findJoiningPoint_5.secondLLLength = findJoiningPoint_5.GetLength(findJoiningPoint_5.secondHead);
            int? result = findJoiningPoint_5.FindCommonPoint();
            Console.WriteLine(result != null ? $"Common point of both the lists is = {result}" : "Both  linked lists are parallel");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
