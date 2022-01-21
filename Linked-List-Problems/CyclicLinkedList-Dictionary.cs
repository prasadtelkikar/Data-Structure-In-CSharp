using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class CyclicLinkedList_Dictionary
    {
        private Node head = null;
        private int length = 0;

        private void InsertNodeAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(head == null)
            {
                head = newNode;
                this.length++;
                return;
            }
            newNode.NextNode=head;
            head = newNode;
            this.length++;
            return ;
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertNodeAtBeginning(element);
        }

        private bool IsLinkedListCyclic()
        {
            Dictionary<Node, int> dict = new Dictionary<Node, int>();
            for(var currentNode = head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (dict.ContainsKey(currentNode))
                    return true;
                else
                    dict.Add(currentNode, currentNode.Data);
            }
            return false;
        }
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            CyclicLinkedList_Dictionary cyclicLinkedList_Dictionary = new CyclicLinkedList_Dictionary();
            cyclicLinkedList_Dictionary.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = cyclicLinkedList_Dictionary.head.NextNode.NextNode.NextNode;
            var lastNode = cyclicLinkedList_Dictionary.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var isCyclic = cyclicLinkedList_Dictionary.IsLinkedListCyclic();

            Console.WriteLine(isCyclic ? "Given linked list is Cyclic" : "Given linked list NOT a Cyclic");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }

            public Node(int data)
            {
                this.Data = data;
            }
        }
    }
}
