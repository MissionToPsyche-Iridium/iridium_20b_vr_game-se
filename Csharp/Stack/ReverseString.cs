using System;
using System.Collections.Generic;

class ReverseStringUsingStack
{
    static void Main()
    {
        Console.Write("Enter a string to reverse: ");
        string input = Console.ReadLine();

        Stack<char> stack = new Stack<char>();

        foreach (char ch in input)
        {
            stack.Push(ch);
        }

        Console.Write("Reversed string: ");
        
        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }

        Console.WriteLine();
    }
}
