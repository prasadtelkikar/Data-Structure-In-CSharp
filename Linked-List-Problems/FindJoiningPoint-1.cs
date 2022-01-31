using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindJoiningPoint_1
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
                    if(firstHead != null)
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

        private int FindCommonPoint()
        {
            for (Node firstLLCurrentNode = firstHead; firstLLCurrentNode != null; firstLLCurrentNode = firstLLCurrentNode.NextNode)
            {
                for (Node secondLLCurrentNode = secondHead; secondLLCurrentNode != null; secondLLCurrentNode = secondLLCurrentNode.NextNode)
                {
                    if (firstLLCurrentNode == secondLLCurrentNode)
                        return firstLLCurrentNode.Data;
                }
            }
            return -1;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            FindJoiningPoint_1 findJoiningPoint_1 = new FindJoiningPoint_1();
            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            findJoiningPoint_1.InsertMultiple(firstLinkedListData);
            findJoiningPoint_1.InsertMultiple(secondLinkedListData, false);

            findJoiningPoint_1.secondHead.NextNode.NextNode.NextNode.NextNode.NextNode = findJoiningPoint_1.firstHead.NextNode.NextNode;
            int result = findJoiningPoint_1.FindCommonPoint();
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
