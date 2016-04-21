using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2Test
{
    [TestClass]
    public class MyQueueTest
    {
        [TestMethod]
        public void CountTest()
        {
            //Arange
            MyQueue<int> queue=new MyQueue<int>(new[]{1,2,3,4,5,6,7});
            //Act
            int count = queue.Count;
            //Assert
            Assert.AreEqual(7,count);
        }
        [TestMethod]
        public void CountAddElemTest()
        {
            //Arange
            MyQueue<int> queue = new MyQueue<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            //Act
            queue.Enqueue(8);
            int count = queue.Count;
            //Assert
            Assert.AreEqual(8, count);
        }
        [TestMethod]
        public void EnqueueElemContainsTest()
        {
            //Arange
            MyQueue<string> queue = new MyQueue<string>(new[] { "1day", "2day", "3day", "4day", "5day", "6day" });
            //Act
            queue.Enqueue("7day");
            //Assert
            Assert.IsTrue(queue.Contains("7day"));
        }

        [TestMethod]
        public void DequeueElemContainsTest()
        {
            //Arange
            MyQueue<string> queue = new MyQueue<string>(new[] { "1day", "2day", "3day", "4day", "5day"});
            //Act
            queue.Dequeue();
            //Assert
            Assert.IsFalse(queue.Contains("6day"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueElemExeptionContainsTest()
        {
            //Arange
            MyQueue<string> queue = new MyQueue<string>(new string[]{});
            //Act
            queue.Dequeue();
            //Assert
            Assert.AreEqual(0,queue.Count);
        }
        [TestMethod]
        public void ClearElemTest()
        {
            //Arange
            MyQueue<int> queue = new MyQueue<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            //Act
            queue.Clear();
            int count = queue.Count;
            //Assert
            Assert.AreEqual(0, count);
        }

    }
}
