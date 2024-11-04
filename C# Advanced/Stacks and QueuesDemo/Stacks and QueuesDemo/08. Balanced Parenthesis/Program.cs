using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                {
                    stack.Push(item);
                    break;
                }

                if (item == ')' && stack.Peek()== '(')
                {
                    stack.Pop();
                }

                else if (item == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }

                else if (item == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
