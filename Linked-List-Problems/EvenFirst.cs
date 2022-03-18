using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class EvenFirst
    {

        private Node head = null;
        private Node evenList = null;
        private Node oddList = null;
        private void InsertAtBeginning(int data)
        {
            var newNode = CreateNewNode(data);
            if(data % 2 == 0)
            {
                if(evenList != null)
                    newNode.NextNode = evenList;
                evenList = newNode;
            }
            else
            {
                if(oddList != null)
                    newNode.NextNode= oddList;
                oddList = newNode;
            }
        }

        private void InsertMultiple(IList<int> elements)
        {
            foreach (var element in elements)
                InsertAtBeginning(element);


            head = evenList;
            Node curretNode = evenList;
            while (curretNode.NextNode != null)
                curretNode = curretNode.NextNode;
            curretNode.NextNode = oddList;
        }
        private void Display()
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            EvenFirst evenFirstObj = new EvenFirst();
            evenFirstObj.InsertMultiple(elements);

            evenFirstObj.Display();
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
