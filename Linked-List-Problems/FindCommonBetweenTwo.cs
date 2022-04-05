using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class FindCommonBetweenTwo
    {

        Node firstHead = null;
        Node secondHead = null;
        private void InsertAtBeginning(int data, bool isFirst)
        {
            if (isFirst)
                firstHead = InsertAtBeginning(firstHead, data);
            else
                secondHead = InsertAtBeginning(secondHead, data);
        }
        private Node InsertAtBeginning(Node head, int data)
        {
            var newNode = CreateNewNode(data);
            if (head == null)
            {
                head = newNode;
                return head;
            }
            newNode.NextNode = head;
            head = newNode;
            return head;
        }
        private void InsertMultiple(IList<int> elements, bool isFirst)
        {
            foreach (var element in elements)
                InsertAtBeginning(element, isFirst);
        }
        private void Display(Node head)
        {
            for (var currentNode = head; currentNode != null; currentNode=currentNode.NextNode)
                Console.Write(currentNode.NextNode != null ? $"{currentNode.Data} -> " : $"{currentNode.Data} -> NULL{Environment.NewLine}");
        }

        private Node FindCommonList()
        {
            Node result = null;

            while(firstHead != null && secondHead != null)
            {
                if (firstHead.Data == secondHead.Data)
                {
                    var temp = CreateNewNode(firstHead.Data);
                    if (result == null)
                        result = temp;
                    else
                    {
                        var currentNode = result;
                        while (currentNode.NextNode != null)
                            currentNode = currentNode.NextNode;

                        currentNode.NextNode = temp;
                    }
                    firstHead = firstHead.NextNode;
                    secondHead = secondHead.NextNode;
                }
                else if (firstHead.Data < secondHead.Data)
                    secondHead = secondHead.NextNode;
                else
                    firstHead = firstHead.NextNode;
            }

            return result;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            var firstNumber = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var secondNumber = new List<int> { 5, 6, 7, 8, 9, 10 };
            
            FindCommonBetweenTwo findCommon = new FindCommonBetweenTwo();
            findCommon.InsertMultiple(firstNumber, true);
            findCommon.InsertMultiple(secondNumber, false);

            findCommon.Display(findCommon.firstHead);
            findCommon.Display(findCommon.secondHead);

            var result = findCommon.FindCommonList();
            findCommon.Display(result);
        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
