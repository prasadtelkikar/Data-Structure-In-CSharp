using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CyclicLinkedList_Floyd
    {
        private Node head = null;
        private int length = 0;

        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head == null)
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
            foreach(var element in elements)
                InsertAtBeginning(element);
        }

        //Floyd Algorithm: Interesting, Probably most efficient. Two pointer movement.
        private bool IsLinkedListCyclic()
        {
            var fastPointer = head;
            var slowPointer = head;

            //If list is cyclic, at some point fast pointer and slow pointer will point to same node.
            while(slowPointer != null && fastPointer != null && fastPointer.NextNode != null)
            {
                fastPointer = fastPointer.NextNode.NextNode;
                slowPointer = slowPointer.NextNode;

                if (fastPointer == slowPointer)
                    return true;
            }
            return false;
        }
        private Node CreateNewNode(int data) => new Node(data);
        
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            CyclicLinkedList_Floyd cyclicLinkedList_Floyd = new CyclicLinkedList_Floyd();
            cyclicLinkedList_Floyd.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = cyclicLinkedList_Floyd.head.NextNode.NextNode.NextNode;
            var lastNode = cyclicLinkedList_Floyd.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var isCyclic = cyclicLinkedList_Floyd.IsLinkedListCyclic();

            Console.WriteLine(isCyclic ? "Given linked list is Cyclic" : "Given linked list NOT a Cyclic");

        }
        public class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data)
                { this.Data = data; }
        }
    }
}
