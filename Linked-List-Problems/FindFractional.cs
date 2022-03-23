using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindFractional
    {
        private Node head = null;
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
        private void Display()
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }
        private Node CreateNewNode(int data) => new Node(data);

        //Return last factorial number from the given list.
        private Node FindFractionalNode(int k)
        {
            try
            {
                Node fractionalNode = null;
                int i = 0; //Zero Based indexing
                for (Node currentNode = head; currentNode != null; currentNode = currentNode.NextNode)
                {
                    if(i % k == 0)
                    {
                        if (currentNode == head)
                            fractionalNode = currentNode;
                        else
                            fractionalNode = currentNode;

                    }
                }
                return fractionalNode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static void Main(string[] args)
        {
            var elements = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Enter fractional number i.e k = ");
            int k = int.Parse(Console.ReadLine());
            FindFractional findFractional = new FindFractional();
            findFractional.InsertMultiple(elements);

            findFractional.Display();

            var result = findFractional.FindFractionalNode(k);
            Console.WriteLine(result.Data);

        }


        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
