using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Problems
{
    public class SymbolBalancing
    {
        private Node top = null;
        private void Push(char data)
        {
            var newNode = CreateNewNode(data);
            if(top == null)
            {
                top = newNode;
                return;
            }
            newNode.NextNode = top;
            top = newNode;
        }

        public void PushMultiple(string inputStr)
        {
            foreach (char item in inputStr)
                Push(item);
        }

        private bool IsStackEmpty() => top == null;

        private char Pop()
        {
            if (IsStackEmpty())
                return '\0';
            var temp = top.Data;
            top = top.NextNode;
            return temp;
        }

        private bool IsEquationBalanced(string equation)
        {
            var openingBrackets = "([{";
            var closingBrackets = ")]}";
            foreach (char eq in equation)
            {
                if(openingBrackets.Contains(eq))
                    Push(eq);
                else if(closingBrackets.Contains(eq))
                {
                    if(top==null)
                        return false;
                    var openingElementIndex = openingBrackets.IndexOf(Pop());
                    var closingElementIndex = closingBrackets.IndexOf(eq);
                    if (openingElementIndex != closingElementIndex)
                        return false;
                }
            }
            return true;
        }

        private Node CreateNewNode(char data) => new Node(data);

        public static void Main(string[] args)
        {
            SymbolBalancing symbol = new SymbolBalancing();
            Console.WriteLine("Enter an equation");
            var equation = Console.ReadLine();
            var isBalanced = symbol.IsEquationBalanced(equation);
            Console.WriteLine(isBalanced ? "Equation is Balanced" : "Equation is Not balanced");
            Console.ReadKey();
        }
        private class Node
        {
            public char Data { get; set; }
            public Node NextNode { get; set; }
            public Node(char data) { this.Data = data; this.NextNode = null; }
        }
    }
}
