using System;
using System.Diagnostics;

namespace ConsoleApplication1

{
    internal class Program
    {

        static int[] triple(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * 3;
            }

            return array;
        }

        static int factorial(int n)
        {
            if (n == 0) return 1;
            
            return n * factorial(n - 1);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //this is a comment
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
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
            
            int[] testArray = {1,2,3,4,5,6,7,8,9,10};
            
            triple(testArray);

            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }

            Console.WriteLine("The factorial of 5 is " + factorial(5));

            Calculator calculator = new Calculator();

            Console.WriteLine("1 + 2 = " + calculator.add(1, 2));
            Console.WriteLine("2 * 59 = " + calculator.Multiply(2, 59));

            MyStack myStack = new MyStack(1);
            Debug.Assert(myStack.getSize() == 1, "stack size incorrect");
            myStack.push(2);
            Debug.Assert(myStack.getSize() == 2, "stack size incorrect");
            myStack.printStack();
            myStack.push(99);
            Debug.Assert(myStack.getSize() == 3, "stack size incorrect");
            myStack.printStack();
            Console.WriteLine(myStack.getSize());
            myStack.push(2);myStack.push(3);myStack.push(4);
            Debug.Assert(myStack.getSize() == 6, "stack size incorrect");
            myStack.push(6);myStack.push(1);myStack.push(4);
            Debug.Assert(myStack.getSize() == 9, "stack size incorrect");
            myStack.push(222);myStack.push(244);myStack.push(662);
            Debug.Assert(myStack.getSize() == 12, "stack size incorrect");
            Console.WriteLine(myStack.getSize());
            myStack.printStack();
            Console.WriteLine(myStack.peek());
            Console.WriteLine(myStack.pop());
            myStack.printStack();
            Console.WriteLine(myStack.getSize());

            Debug.Assert(myStack.getSize() == 11, "stack size incorrect");
            
            Debug.Assert(myStack.peek() == 244, "stack size incorrect");
            Debug.Assert(myStack.pop() == 244, "stack size incorrect");
            Debug.Assert(myStack.getSize() == 10, "stack size incorrect");








        }
    }
}