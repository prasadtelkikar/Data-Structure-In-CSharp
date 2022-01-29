using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class ReverseLinkedList_Recursion
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head != null)
                newNode.NextNode = head;
            head = newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private void Display(Node head)
        {
            for (Node currentNode = head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (currentNode.NextNode == null)
                    Console.WriteLine($"{currentNode.Data} -> null");
                else
                    Console.Write($"{currentNode.Data} -> ");
            }
        }

        //Help: https://youtu.be/KYH83T4q6Vs
        private Node ReveseLinkedListRecursively(Node currentNode)
        {
            if (currentNode == null)
                return null;
            else if (currentNode.NextNode == null)
                return currentNode;

            //Recursively reach to the last node
            var newHeadNode = ReveseLinkedListRecursively(currentNode.NextNode);

            //Get the next node of current Node.
            var actualNextOfCurrentNode = currentNode.NextNode;
            //For first Pass actualNextOfCurrentNode.NextNode will set to last node of the list.
            actualNextOfCurrentNode.NextNode = currentNode;
            //Move null one by one to create end of the list.
            currentNode.NextNode = null;

            return newHeadNode;
        }

        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ReverseLinkedList_Recursion reverseObj = new ReverseLinkedList_Recursion();
            reverseObj.InsertMultiple(list);

            Console.WriteLine("Before Reverse");
            reverseObj.Display(reverseObj.head);

            var reverseList = reverseObj.ReveseLinkedListRecursively(reverseObj.head);

            Console.WriteLine("After Reverse");
            reverseObj.Display(reverseList);
        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
