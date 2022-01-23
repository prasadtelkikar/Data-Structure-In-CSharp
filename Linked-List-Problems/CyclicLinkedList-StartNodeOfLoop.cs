using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CyclicLinkedList_StartNodeOfLoop
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
            foreach (var element in elements)
                InsertAtBeginning(element);
        }

        private Node GetStartNodeOfLoop()
        {
            var fastPointer = head;
            var slowPointer = head;
            var isCyclic = false;
            while(slowPointer != null && fastPointer != null && fastPointer.NextNode != null)
            {
                fastPointer = fastPointer.NextNode.NextNode;
                slowPointer = slowPointer.NextNode;
                if(fastPointer == slowPointer)
                {
                    isCyclic = true;
                    break;
                }
            }
            if(isCyclic)
            {
                slowPointer = head;
                while (true)
                {
                    slowPointer = slowPointer.NextNode;
                    fastPointer = fastPointer.NextNode;
                    if (slowPointer == fastPointer && slowPointer.Date == fastPointer.Date)
                        return slowPointer;

                }
            }
            return null;
        }

        private Node CreateNewNode(int data) => new Node(data);
        
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            CyclicLinkedList_StartNodeOfLoop startNodeObj = new CyclicLinkedList_StartNodeOfLoop();
            startNodeObj.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = startNodeObj.head.NextNode.NextNode.NextNode;
            var lastNode = startNodeObj.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var result = startNodeObj.GetStartNodeOfLoop();

            Console.WriteLine(result == null ? $"Linked list is not cyclic" : $"Linked list is cyclic and start node is {result.Date}");
        }

        private class Node
        {
            public int Date { get; set; }
            public Node NextNode { get; set; }
            public Node(int data)
            {
                this.Date = data;
            }
        }
    }
}
