using System;

namespace ConsoleApplication1

{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //this is a comment
            Console.WriteLine("What's your name?");
            String name = Console.ReadLine();
            Console.WriteLine("Hi " + name);

            string[] cars = { "Ford Mustang", "Toyota Supra", "Chevrolet Corvette" };
            //string is in lowercase, it's also a primitive
            Console.WriteLine("I like the " + cars[0]);

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }
            //very similar to java. (and js, and others)
            
            Car car = new Car();
            Console.WriteLine("My car's color is " + car.getColor());




        }
    }
}