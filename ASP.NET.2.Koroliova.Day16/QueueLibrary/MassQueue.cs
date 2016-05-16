using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibrary
{
    public class MassQueue<T> : IQueue<T>, IEnumerable<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private int size;
        private int version;
        static readonly T[] emptyArray = new T[0];
        private const int defaultCapacity = 4;

        #region Ctors
        public MassQueue()
        {
            array = emptyArray;
        }
        public MassQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();

            array = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;
            version = 0;
        }

        public MassQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            array = new T[defaultCapacity];
            size = 0;
            version = 0;
            foreach (T item in collection)
            {
                Enqueue(item);
            }

        }
        #endregion

        #region Field
        public int Count
        {
            get { return size; }
        }
        #endregion

        #region Public Methods
        public void Clear()
        {
            if (head < tail)
                Array.Clear(array, head, size);
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, tail);
            }

            head = 0;
            tail = 0;
            size = 0;
            version++;
        }
        public void Enqueue(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (size == array.Length)
            {
                int newcapacity = array.Length * 2;
                if (newcapacity < array.Length + 4)
                {
                    newcapacity = array.Length + 4;
                }
                SetCapacity(newcapacity);
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            size++;
            version++;
        }


        public void TrimExcess()
        {
            int threshold = (int)((array.Length) * 0.9);
            if (size < threshold)
            {
                SetCapacity(size);
            }
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (((IList<T>)array).Contains(item))
                return true;
            return false;
        }


        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException();

            return array[head];
        }
        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException();

            T removed = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            size--;
            version++;
            return removed;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator(this);
        }
        #endregion

        private void SetCapacity(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentNullException();
            T[] newarray = new T[capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newarray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, newarray, 0, array.Length - head);
                    Array.Copy(array, 0, newarray, array.Length - head, tail);
                }
            }

            array = newarray;
            head = 0;
            tail = (size == capacity) ? 0 : size;
            version++;
        }
        internal T GetElement(int i)
        {
            return array[(head + i) % array.Length];
        }

        #region Class QueueEnumerator
        class QueueEnumerator : IEnumerator<T>
        {
            private int currentIndex = -1;
            private readonly MassQueue<T> collection;
            private T item;
            private readonly int version;

            public QueueEnumerator(MassQueue<T> collection)
            {

                this.collection = collection;
                item = default(T);
                version = collection.version;
            }

            public bool MoveNext()
            {
                if (version != collection.version)
                {
                    throw new InvalidOperationException();
                }
                if (currentIndex == -2)
                    return false;
                currentIndex++;
                if (currentIndex == collection.Count)
                {
                    currentIndex = -2;
                    item = default(T);
                    return false;
                }
                item = collection.array[(collection.head + currentIndex) % collection.array.Length];
                return true;
            }

            public T Current
            {
                get
                {
                    if (currentIndex < 0)
                        throw new InvalidOperationException();
                    return item;
                }

            }

            public void Reset()
            {
            }


            object IEnumerator.Current
            {

                get
                {
                    if (version != collection.version)
                    {
                        throw new InvalidOperationException();
                    }
                    return Current;
                }
            }


            public void Dispose()
            {
            }
        }
        #endregion
    }
}
