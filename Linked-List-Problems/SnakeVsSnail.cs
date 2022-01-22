using System;
using System.Collections.Generic;

namespace Linked_List_Problems
{
    public class SnakeVsSnail
    {
        private Node head = null;
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

        //Using Floyd algorithm
        private bool IsLinkedListCyclic()
        {
            var fastNode = head;
            var slowNode = head;
            while (slowNode != null && fastNode != null && fastNode.NextNode != null)
            {
                fastNode = fastNode.NextNode.NextNode;
                slowNode = slowNode.NextNode;
                if (fastNode == slowNode)
                    return true;
            }
            return false;
        }

        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6 };
            SnakeVsSnail snakeVsSnail_obj = new SnakeVsSnail();
            snakeVsSnail_obj.InsertMultiple(elements);

            //Cyclic third to sixth
            var thirdNode = snakeVsSnail_obj.head.NextNode.NextNode.NextNode;
            var lastNode = snakeVsSnail_obj.head.NextNode.NextNode.NextNode.NextNode?.NextNode;
            lastNode.NextNode = thirdNode;

            var isCyclic = snakeVsSnail_obj.IsLinkedListCyclic();

            Console.WriteLine(isCyclic ? "Given linked list is Snail" : "Given linked list is Snake");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) { Data = data; }
        }
    }
}
