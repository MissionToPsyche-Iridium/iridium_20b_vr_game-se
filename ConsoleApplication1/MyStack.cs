using System;

namespace ConsoleApplication1
{
    public class MyStack
    {
        private int[] stack;
        private int size;

        public int getSize()
        {
            return size;
        }
        
        
        public MyStack(int n)
        {
            stack = new int[10];
            stack[0] = n;
            size = 1;
        }

        private void sizeUp()
        {
            int[] newStack = new int[stack.Length * 2];

            for (int i = 0; i < stack.Length; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }

        public int peek()
        {
            return stack[size - 1];
        }

        public int pop()
        {
            int rval = stack[size - 1];
            stack[size - 1] = 999;
            size--;
            return rval;
        }

        public void push(int n)
        {
            if (size == stack.Length)
            {
                sizeUp();
            }
            
            stack[size] = n;
            size++;
        }

        public void printStack()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
        
        
        
        
    }
}