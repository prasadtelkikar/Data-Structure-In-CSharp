﻿using System;
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
            Node result = null;
            if (firstListNode == null)
                return secondListNode;
            if(secondListNode == null)
                return firstListNode;
            if(firstListNode.Data < secondListNode.Data)
            {
                result = firstListNode;
                result.NextNode = MergeList(firstListNode.NextNode, secondListNode);
            }
            else
            {
                result = secondListNode;
                result.NextNode = MergeList(firstListNode, secondListNode.NextNode);
            }
            return result;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            MergeTwoSortedList_Recursive mergeSortedList = new MergeTwoSortedList_Recursive();

            var firstLinkedListData = new List<int>() { 600, 500, 400, 300, 200, 100 };
            var secondLinkedListData = new List<int>() { 250, 200, 150, 100, 50 };
            mergeSortedList.InsertMultiple(firstLinkedListData);
            mergeSortedList.InsertMultiple(secondLinkedListData, false);

            Console.WriteLine("First Linked list");
            mergeSortedList.Display(mergeSortedList.firstHead);
            Console.WriteLine("Second Linked list");
            mergeSortedList.Display(mergeSortedList.secondHead);

            var result = mergeSortedList.MergeList(mergeSortedList.firstHead, mergeSortedList.secondHead);
            Console.WriteLine("Final Merged list");
            mergeSortedList.Display(result);

        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }

    }
}
