using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class IsLinkedListPalindrome
    {
        private Node head = null;
        private int length = 0;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                length++;
                return;
            }
            newNode.NextNode = head;
            length++;
            head = newNode;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        //Buggy code, need to fix
        private bool IsPalindrome()
        {
            Node middle = FindMiddleNode();
            Node reverseList = ReverseLinkedList();
            while (reverseList != null && middle != null)
            {
                if (reverseList.Data != middle.Data)
                    return false;
                reverseList = reverseList.NextNode;
                middle = middle.NextNode;
            }
            return true;
        }

        private Node ReverseLinkedList()
        {
            Node currentNode = head;
            Node n = null;
            while(currentNode != null)
            {
                var temp = currentNode.NextNode;
                currentNode.NextNode = n;
                n = currentNode;
                currentNode = temp;
            }
            return n;
        }

        private Node FindMiddleNode()
        {
            Node fastNode = head;
            Node slowNode = head;
            while(fastNode != null && fastNode.NextNode != null)
            {
                fastNode = fastNode.NextNode.NextNode;
                slowNode = slowNode.NextNode;
            }
            return slowNode;
        }

        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> {3, 2, 1, 3, 2, 1 };
            IsLinkedListPalindrome isPalindrome = new IsLinkedListPalindrome();
            isPalindrome.InsertMultiple(elements);

            Console.WriteLine("Actual Linked List:");
            isPalindrome.Display(isPalindrome.head);

            var result = isPalindrome.IsPalindrome();
            Console.WriteLine(result ? "Yes list is palindrome" : "No list is not a palindrome");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
