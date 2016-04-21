using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Generic class Queue.
    /// </summary>
    /// <typeparam name="T">Type of elements in our queue.</typeparam>
    public class MyQueue<T> : IEnumerable<T>
    {

        #region Fields
        /// <summary>
        /// Generic array.
        /// </summary>
        private T[] elem;
        /// <summary>
        /// Capacity of generic array.
        /// </summary>
        private int startCapacity;
        /// <summary>
        /// Start index.
        /// </summary>
        private int begin;
        /// <summary>
        /// End index.
        /// </summary>
        private int end;
        #endregion

        #region Property
        /// <summary>
        ///  Gets the number of elements contained in the Queue<T>.
        /// </summary>
        public int Count { get; private set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Constructor with default capacity or capacity given by user.
        /// </summary>
        /// <param name="cap">Given capacity.</param>
        public MyQueue()
        {
            int cap = 9;
            startCapacity = cap;
            elem = new T[startCapacity];
            Count = 0;
            begin = 0;
            end = -1;

        }
        public MyQueue(int cap ):this()
        {
            if (cap < 0)
                throw new ArgumentOutOfRangeException();
            startCapacity = cap;
        }

        /// <summary>
        /// Initializes a new instance of the Queue<T> class that contains elements copied from the specified
        /// collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection"></param>
        public MyQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            IEnumerable<T> items = collection as T[] ?? collection.ToArray();
            startCapacity = items.Count();
            Count = 0;
            begin = 0;
            end = -1;
            elem = new T[startCapacity];
            foreach (T item in items)
            {
                Enqueue(item);
            }

        }
        #endregion

        #region BoolMethod

        /// <summary>
        /// Determines whether an element is in the Queue<T>
        /// </summary>
        /// <param name="item">Inspection item</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (((IList<T>)elem).Contains(item))
                return true;
            return false;
        }
        #endregion

        #region VoidMethods

        /// <summary>
        /// Removes all objects from the Queue<T>.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
                elem[i] = default(T);
            begin = 0;
            end = -1;
            Count = 0;
        }
        /// <summary>
        /// Adds an object to the end of the Queue<T>.
        /// </summary>
        /// <param name="item">Element which need to add</param>
        public void Enqueue(T item)
        {
            if (end > startCapacity)
                end -= startCapacity + 1;
            else end += 1;
            elem[end] = item;
            Count++;
            if (Count == startCapacity)
            {
                startCapacity *= 2;
                T[] array = new T[startCapacity];
                if (begin <= end)
                    elem.CopyTo(array, 0);
                else
                {
                    Array.Copy(elem, begin, array, 0, elem.Length - begin);
                    Array.Copy(elem, 0, array, elem.Length - begin, end + 1);
                }
                elem = new T[startCapacity];
                elem = array;
            }


        }
        /// <summary>
        /// Sets the capacity to the actual number of elements in the Queue<T>.
        /// </summary>
        public void TrimExcess()
        {
            if ((double)Count / startCapacity > 0.9) return;
            T[] newArray = new T[Count + 1];
            Array.Copy(elem, newArray, Count);
            elem = newArray;
        }
        #endregion

        #region MethodsRetValue
        
        /// <summary>
        /// Removes and returns the object at the beginning of the Queue<T>
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();


            Count--;
            T temp = elem[begin];
            if (begin > startCapacity)
                begin -= startCapacity + 1;
            else begin += 1;
            return temp;

        }

        /// <summary>
        /// Returns the object at the beginning of the Queue<T> without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return elem[begin];
        }
        /// <summary>
        /// Returns an enumerator that iterates through the Queue<T>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (begin < end)
                for (int i = begin; i < end + 1; i++)
                    yield return elem[i];
            else
            {
                for (int i = begin; i < startCapacity; i++)
                    yield return elem[i];
                for (int i = 0; i < end + 1; i++)
                    yield return elem[i];
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

    }
}
