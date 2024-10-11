using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Please enter a valid age.");
        }

        Console.WriteLine($"\nHello, {name}!");

        if (age >= 18)
        {
            Console.WriteLine("You are old enough to vote.");
        }
        else
        {
            Console.WriteLine("You are not old enough to vote.");
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
