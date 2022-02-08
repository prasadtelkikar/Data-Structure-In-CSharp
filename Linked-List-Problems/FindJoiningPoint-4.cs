using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindJoiningPoint_4
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
            Dictionary<Node, int> nodes = new Dictionary<Node, int>();
            for(Node currentNode = firstHead; currentNode!= null;currentNode=currentNode.NextNode)
                nodes.Add(currentNode, currentNode.Data);

            for (Node currentNode = secondHead; currentNode != null; currentNode=currentNode.NextNode)
                if(nodes.ContainsKey(currentNode))
                    return nodes[currentNode];

            return null;
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            FindJoiningPoint_4 findJoiningPoint_4 = new FindJoiningPoint_4();

            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            findJoiningPoint_4.InsertMultiple(firstLinkedListData);
            findJoiningPoint_4.InsertMultiple(secondLinkedListData, false);

            findJoiningPoint_4.secondHead.NextNode.NextNode.NextNode.NextNode.NextNode = findJoiningPoint_4.firstHead.NextNode.NextNode;
            int? result = findJoiningPoint_4.FindCommonPoint();
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
