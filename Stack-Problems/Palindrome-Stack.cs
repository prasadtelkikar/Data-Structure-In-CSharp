using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Problems
{
    //For linked list apparoach, Check  Linked_List_Problems -> IsLinkedListPalindrome
    public class Palindrome_Stack
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

        private char Pop()
        {
            var topChar = top.Data;
            top = top.NextNode;
            return topChar;
        } 

        private bool IsPalindromeCheck(string input)
        {
            bool isFirstPart = true;
            if (!input.Contains('X'))
                throw new Exception("Invalid input string");
            foreach(char c in input)
            {
                if(c == 'X')
                    isFirstPart = false;
                else if(isFirstPart)
                    Push(c);
                else if(c !=  Pop())
                        return false;
            }
            return true;
        }

        private Node CreateNewNode(char data) => new Node(data);
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Palindrome_Stack palindrome = new Palindrome_Stack();
            bool isPalindrome = palindrome.IsPalindromeCheck(input);
            Console.WriteLine(isPalindrome ? "Given string is a Palindrome" : "Given string is NOT a palindrome");
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
