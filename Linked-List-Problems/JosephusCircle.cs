using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linked_List_Problems
{
    public class JosephusCircle
    {
        private Node head = null;

        private void InsertAtBeginning(int data)
        {
            Node newNode = CreateNewNode(data);
            if(head != null) 
                newNode.NextNode = head;
            head = newNode;
        }
        private void ConvertListToCircularList(IList<int> data)
        {
            foreach(var element in data)
                InsertAtBeginning(element);

            Node currentNode = head;
            while(currentNode.NextNode != null)
                currentNode = currentNode.NextNode;
            currentNode.NextNode = head;
        }
        private Node CreateNewNode(int data) => new Node(data);
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number of players");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M i.e. Every M-th player gets eliminated");
            int m = int.Parse(Console.ReadLine());
            JosephusCircle jCircle = new JosephusCircle();

            Node winner = jCircle.GetJosephusPosition(n, m);

            Console.WriteLine($"Last palyer left standing (Josephus position) is {winner.Data}");
        }

        private Node GetJosephusPosition(int numberOfPlayers, int eliminatePosition)
        {

            //Convert Given list into Circular linked list
            ConvertListToCircularList(Enumerable.Range(1, numberOfPlayers).ToList());
            
            //Eliminate each "eliminatePosition" node from the list
            Node currentNode = head;
            for(int i =0; i < numberOfPlayers; i++)
            {
                for (int j = 0; j < eliminatePosition; j++)
                    currentNode = currentNode.NextNode;
                currentNode.NextNode = currentNode.NextNode.NextNode;
            }
            //To make it non-circular
            currentNode.NextNode = null;
            return currentNode;

        }

        private class Node
        {
            public int Data { get; set; }
            public Node NextNode { get; set; }
            public Node(int data) => this.Data = data;
        }
    }

}
