using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CyclicLinkedList_LengthOfCycle
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
        private Node CreateNewNode(int data) => new Node(data);
        
        private int GetLengthOfCycle()
        {
            var fastNode = head;
            var slowNode = head;
            var isCyclic = false;
            var count = 0;
            while(slowNode != null && fastNode != null && fastNode.NextNode!= null)
            {
                fastNode = fastNode.NextNode.NextNode;
                slowNode = slowNode.NextNode;
                if(fastNode == slowNode)
                {
                    isCyclic = true;
                    break;
                }
            }

            if(isCyclic)
            {
                fastNode = fastNode.NextNode;
                while(fastNode != slowNode)
                {
                    fastNode = fastNode.NextNode;
                    count++;
                }
            }
            return count != 0 ? ++count : count; //Additional Check to ++1 if cyclic list.
        }

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            CyclicLinkedList_LengthOfCycle lengthOfCycleObj = new CyclicLinkedList_LengthOfCycle();
            lengthOfCycleObj.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = lengthOfCycleObj.head.NextNode.NextNode.NextNode;
            var lastNode = lengthOfCycleObj.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var count = lengthOfCycleObj.GetLengthOfCycle();

            Console.WriteLine($"Count of nodes in given Cycle is {count}");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) { this.Data = data; }
        }
    }
}
