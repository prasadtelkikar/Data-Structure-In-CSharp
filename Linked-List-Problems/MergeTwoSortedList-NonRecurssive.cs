using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class MergeTwoSortedList_NonRecurssive
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

        //Source: StackOverflow - https://stackoverflow.com/questions/10707352/interview-merging-two-sorted-singly-linked-list
        private Node MergeList(Node firstListNode, Node secondListNode)
        {

            if (firstListNode == null)
                return secondListNode;
            if (secondListNode == null)
                return firstListNode;

            Node head;
            //If first node of first list is small then make head as first list
            if (firstListNode.Data < secondListNode.Data)
                head = firstListNode;
            else
            {
                //If Second list is small, then assign second list as head and swap List nodes.
                head = secondListNode;
                secondListNode = firstListNode;
                firstListNode = secondListNode;
            }

            //Now first list is going to be sorted
            while (firstListNode.NextNode != null && secondListNode != null)
            {
                //If next element data of first list is greater than second list data then
                if (firstListNode.NextNode.Data > secondListNode.Data)
                {
                    //Take next node of first list into temp
                    Node temp = firstListNode.NextNode;
                    //Attach smallest element to first list
                    firstListNode.NextNode = secondListNode;
                    //move larger data to the second list
                    secondListNode = temp;
                }
                //Keep moving**
                firstListNode = firstListNode.NextNode;
            }
            firstListNode.NextNode = secondListNode;
            return head;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            MergeTwoSortedList_NonRecurssive mergeSortedList = new MergeTwoSortedList_NonRecurssive();

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
