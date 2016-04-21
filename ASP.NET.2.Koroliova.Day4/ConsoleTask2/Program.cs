using System;
using System.Collections.Generic;
using Task2;


namespace ConsoleTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> numbers = new MyQueue<int>();
            MyQueue<string> strings = new MyQueue<string>(8);
            char[] charArray = { 'H', 'i', ',', 'g', 'u', 'y', 's', '!' };
            MyQueue<char> chars = new MyQueue<char>(charArray);
            Console.WriteLine("String count: ");
            Console.WriteLine(strings.Count);
            strings.Enqueue("one");
            strings.Enqueue("two");
            strings.Enqueue("three");
            strings.Enqueue("fore");
            strings.Enqueue("five");
            strings.Enqueue("six");
            strings.Enqueue("seven");
            strings.Enqueue("eight");
            Console.WriteLine("String queue after adding 8 string: ");
            foreach (var elem in strings)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("\nIs 'three' contain in string queue:\n" + strings.Contains("three"));
            Console.WriteLine(strings.Peek());
            strings.Enqueue("nine");
            Console.WriteLine("Queue + 'nine':");
            foreach (var elem in strings)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("Remove and return firs element:");
            Console.WriteLine("\n" + strings.Dequeue() + "\n");
           
            foreach (var elem in strings)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("Count of queue:\n"+strings.Count);
           
            strings.Enqueue("ten");
            strings.Enqueue("eleven");
            Console.WriteLine("Queue + 'ten' and 'eleven':");
            foreach (var elem in strings)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("\nChar array: ");
            foreach (var elem in chars)
            {
                Console.Write(elem);
            }

            chars.Clear();
            Console.WriteLine("Char count after Clearing: \n" + chars.Count);
            numbers.Enqueue(1);
            numbers.Enqueue(2);
            numbers.Enqueue(3);
            numbers.Enqueue(4);
            numbers.Enqueue(5);
            numbers.Enqueue(6);
            numbers.Enqueue(7);
            numbers.Enqueue(8);
            numbers.Enqueue(9);
            numbers.Enqueue(10);
            numbers.Enqueue(11);
            Console.WriteLine("Adding 11 elements in queue numbers: \n");
            foreach (var elem in numbers)
            {
                Console.Write(elem);
            }
            //Array array1 = numbers.ToArray();
            //Array array2 = strings.ToArray();
            //Console.WriteLine("\n" + array1.GetType());
            //Console.WriteLine("\n" + array2.GetType());
            Console.ReadKey();

        }
    }
}
