using System;

class AverageUsingArray
{
    static void Main()
    {
        int[] numbers = new int[5];

        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("Enter number {0}: ", i + 1);
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double average = (double)sum / numbers.Length;
        
        Console.WriteLine("The average is: " + average);
    }
}
