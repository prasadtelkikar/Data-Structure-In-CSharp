using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Problems
{
    public class Palindrome_brute_force
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isPalindrome = FindPalindrome(input);
            Console.WriteLine(isPalindrome ? $"{input} string is a palindrome" : $"{input} string is NOT a palindrome");
            Console.ReadKey();
        }

        private static bool FindPalindrome(string input)
        {
            int startIndex = 0;
            int endIndex = input.Length-1;
            while(startIndex < endIndex && input[startIndex] == input[endIndex])
            {
                startIndex++;
                endIndex--;
            }
            return !(startIndex<endIndex);
        }
    }
}
