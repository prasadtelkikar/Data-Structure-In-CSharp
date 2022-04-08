using System;

namespace Stack_Problems
{
    public class GetMinimumByStack
    {
        private Node top = null;
        private Node minTop = null;

        private void Push(int data)
        {
            var newNode = CreateNewNode(data);
            if (top == null)
            {
                top = newNode;
                minTop = newNode;
                return;
            }
            if(minTop.Data < data)
            {
                var min = CreateNewNode(minTop.Data);
                min.NextData = minTop;

                newNode.NextData = top;

                top = newNode;
                minTop = min; 
            }
            else
            {
                newNode.NextData = top;
                top = newNode;

                var minNewNode = CreateNewNode(data);
                minNewNode.NextData = minTop;
                minTop = minNewNode;
            }
        }

        private int GetMinimum() => minTop.Data;
        private Node CreateNewNode(int data) => new Node(data);

        public static void Main(string[] args)
        {
            GetMinimumByStack getMin = new GetMinimumByStack();
            getMin.Push(2);
            getMin.Push(6);
            getMin.Push(4);
            getMin.Push(1);
            getMin.Push(5);
            Console.WriteLine($"Min From input stack = {getMin.GetMinimum()}");
        }
        private class Node
        {
            public int Data { get; set; }
            public Node NextData { get; set; }
            public Node(int data) { this.Data = data; this.NextData = null; }
        }
    }
}
