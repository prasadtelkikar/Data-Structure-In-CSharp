using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class IsLinkedListPalindrome
    {
        private Node head = null;
        private Node secondHalf = null;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            newNode.NextNode = head;
            head = newNode;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private bool IsPalindrome()
        {
            FindMiddleNode();
            ReverseLinkedList();
            bool isPalin = CompareList(head, secondHalf);
            return isPalin;
        }

        private bool CompareList(Node head, Node secondHalf)
        {
            Node temp1 = head;
            Node temp2 = secondHalf;
            while (temp1 != null && temp2 != null)
            {
                if(temp1.Data != temp2.Data)
                    return false;
                temp1 = temp1.NextNode;
                temp2 = temp2.NextNode;
            }
            return true;
        }


        private void ReverseLinkedList()
        {
            Node previous = null;
            Node currentNode = secondHalf;
            Node next = null;
            while(currentNode != null)
            {
                next = currentNode.NextNode;
                currentNode.NextNode = previous;
                previous = currentNode;
                currentNode = next;
            }
            secondHalf = previous;
        }

        private void FindMiddleNode()
        {
            Node fastNode = head;
            Node slowNode = head;
            while(fastNode != null && fastNode.NextNode != null)
            {
                fastNode = fastNode.NextNode.NextNode;
                slowNode = slowNode.NextNode;
            }
            //This is required when list is of odd size.
            if(fastNode != null)
                slowNode = slowNode.NextNode;
            secondHalf = slowNode;
        }

        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> {1, 2, 3, 4, 3, 2, 1 };
            IsLinkedListPalindrome isPalindrome = new IsLinkedListPalindrome();
            isPalindrome.InsertMultiple(elements);

            Console.WriteLine("Actual Linked List:");
            isPalindrome.Display(isPalindrome.head);

            var result = isPalindrome.IsPalindrome();
            Console.WriteLine(result ? "Yes list is palindrome" : "No list is not a palindrome");

            //After isPalindrome check, linked list is distrub. We need extra logic to make it correct
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
