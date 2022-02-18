using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class MergeTwoSortedList_Recursive
    {
        private Node firstHead = null;
        private Node secondHead = null;

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

        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }

        private Node MergeList(Node firstListNode, Node secondListNode)
        {
            //TODO: Add recursive technique to merge two sorted lists
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }

    }
}
