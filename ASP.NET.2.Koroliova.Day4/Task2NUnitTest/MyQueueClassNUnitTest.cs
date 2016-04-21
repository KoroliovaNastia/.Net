using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2NUnitTest
{
    public class MyQueueClassNUnitTest
    {
        [TestCase(new[] { "one", "two", "three", "fore" }, "five", Result = 5)]
        [TestCase(new[] { "1day", "2day", "3day", "4day", "5day", "6day" }, "7day", Result = 7)]
        public int EnqueueElementTest(string[] arr, string elem)
        {
            MyQueue<string> queue = new MyQueue<string>(arr);
            queue.Enqueue(elem);
            return queue.Count;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, Result = 6)]
        [TestCase(new int[] { }, ExpectedException = typeof(InvalidOperationException))]

        public int DequeueElelmentTest(int[] arr)
        {
            MyQueue<int> queue = new MyQueue<int>(arr);
            queue.Dequeue();
            return queue.Count;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, Result = 1)]
        [TestCase(new[] { 0, 2, 0, 4, 0, 8 }, Result = 0)]
        [TestCase(new int[] { }, ExpectedException = typeof(InvalidOperationException))]
        public int PeekElementTest(int[] arr)
        {
            MyQueue<int> queue = new MyQueue<int>(arr);
            return queue.Peek();
        }

        [TestCase(new[] { "green", "red", "blue", "dark", "orange" }, "orange", Result = true)]
        [TestCase(new[] { "green", "red", "blue", "dark", "orange" }, "white", Result = false)]
        public bool Contains(string[] arr, string elem)
        {
            MyQueue<string> queue = new MyQueue<string>(arr);
            return queue.Contains(elem);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, Result = 0)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, Result = 0)]
        public int ClearElememtTest(int[] arr)
        {
            MyQueue<int> queue = new MyQueue<int>(arr);
            queue.Clear();
            return queue.Count;
        }

        [TestCase(19,Result = 0)]
        [TestCase(null,Result = 0)]
        [TestCase(-3, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int CreteQueueTest(int capacity)
        {
            MyQueue<string> queue=new MyQueue<string>(capacity);
            return queue.Count;
        }
    }
}
