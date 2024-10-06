using System;

namespace ConsoleApplication1
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public int add(int a, int b)
        {
            return a + b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            try
            {
                int rval = a / b;

            }
            catch (DivideByZeroException e)
            {
                return 0;
            }

            return a / b;
        }
    }
}