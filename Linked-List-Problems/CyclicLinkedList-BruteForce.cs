using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CyclicLinkedList_BruteForce
    {
        private Node head;
        private int length = 0;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                this.length++;
                return;
            }
            newNode.NextNode = head;
            head = newNode;
            this.length++;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private bool IsLinkedListCyclic()
        {
            //I think we can solve it with better logic. (Same problem: Cyclic list with brute force)
            for(var currentNode = head; currentNode != null; currentNode = currentNode.NextNode)    
            {
                int count = 0;
                for (var iteratableNode = currentNode; iteratableNode != null; iteratableNode = iteratableNode.NextNode, count++)
                {
                    //Exit condition for circular list found.
                    if (iteratableNode.NextNode == currentNode)
                        return true;
                    //Exit condition to move to next current node.
                    if (count == this.length)
                        break;
                }
            }
            return false;
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            CyclicLinkedList_BruteForce cyclicLinkedList_BruteForce = new CyclicLinkedList_BruteForce();
            cyclicLinkedList_BruteForce.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = cyclicLinkedList_BruteForce.head.NextNode.NextNode.NextNode;
            var lastNode = cyclicLinkedList_BruteForce.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var isCyclic = cyclicLinkedList_BruteForce.IsLinkedListCyclic();
            Console.WriteLine(isCyclic ? "Linked list is cyclic" : "Linked list is not a cyclic");
        }
        private Node CreateNewNode(int data) => new Node(data);
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data)
            {
                this.Data = data;
                this.NextNode = null;
            }
        }
    }
}
