using System;
using System.Collections.Generic;
using System.Text;

namespace Linked_List_Problems
{
    public class SumNumbers
    {
        Node firstHead = null;
        Node secondHead = null;

        private void InsertAtBeginning(int data, bool isFirst)
        {
            if(isFirst)
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

        public void addListNumbersWrapper()
        {
            Node result = null;
            int firstListLength = 0, secondListLength = 0;
            int carry = 0;

            //Store length of each list
            for (Node itrrNode = firstHead; itrrNode != null; itrrNode = itrrNode.NextNode, firstListLength++) ;
            for (Node itrrNode = secondHead; itrrNode != null; itrrNode = itrrNode.NextNode, secondListLength++) ;

            //Store bigger list in firstHead
            if(firstListLength < secondListLength)
            {
                Node currentList = firstHead;
                firstHead = secondHead;
                secondHead = currentList;
            }

            int diff = Math.Abs(firstListLength - secondListLength);
            Node currentNode = firstHead;
            while(diff-- > 0)
                currentNode = currentNode.NextNode;

            addListNumbers(currentNode, secondHead, ref carry, ref result);
            diff = Math.Abs(firstListLength - secondListLength);
            addRemainingNumbers(firstHead, ref carry, ref result, diff);

            if(carry > 0)
            {
                Node temp = CreateNewNode(carry);
                temp.NextNode = result;
                result = temp;
            }

            //Display result

            Display(result);
        }

        private void addRemainingNumbers(Node firstHead, ref int carry, ref Node result, int diff)
        {
            if (firstHead == null || diff==0)
                return;

            addRemainingNumbers(firstHead.NextNode, ref carry, ref result, diff);
            
            int sum = firstHead.Data + carry;
            carry = sum / 10;
            sum = sum % 10;
            
            Node temp = CreateNewNode(sum);
            temp.NextNode = firstHead;
            result = temp;
        }

        private void addListNumbers(Node currentNode, Node secondHead, ref int carry, ref Node result)
        {
            if (currentNode == null)
                return;

            //recurrsion to reach end of lists
            addListNumbers(currentNode.NextNode, secondHead.NextNode, ref carry, ref result);

            //Now, you are at the end of list. Add the data
            int sum = currentNode.Data + secondHead.Data;

            //store carry
            carry = sum / 10;
            sum = sum % 10;

            Node temp = CreateNewNode(sum);
            temp.NextNode = result;
            result = temp;
            return;
        }

        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {

            var firstNumber = new List<int> { 1, 2, 3 };
            var secondNumber = new List<int> { 5, 6, 7 };

            SumNumbers numSums = new SumNumbers();
            numSums.InsertMultiple(firstNumber, true);
            numSums.InsertMultiple(secondNumber, false);

            numSums.Display(numSums.firstHead);
            numSums.Display(numSums.secondHead);

            numSums.addListNumbersWrapper();
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }
}
