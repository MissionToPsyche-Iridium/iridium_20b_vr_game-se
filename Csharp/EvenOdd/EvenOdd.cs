using System;

namespace Csharp
{
    class EvenOdd 
    {
        static void Main() 
        {
            Console.WriteLine("Enter an integer");
            int numberInput =  Convert.ToInt32(Console.ReadLine());

            if (numberInput % 2 == 0) 
            {
                Console.WriteLine("The number is even");
            }
            else 
            {
                Console.WriteLine("The number is odd");
            }
        }
    }

}