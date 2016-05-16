using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibrary
{
    public class LinkedListQueue<T> : IQueue<T>, IEnumerable<T>
    {
        internal LListNode<T> head;
        internal int count;
        private int version;

        #region Ctors
        public LinkedListQueue()
        {
        }

        public LinkedListQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            foreach (var item in collection)
            {
                Enqueue(item);
            }
            version = 0;
        }
        #endregion

        #region Fields
        public int Count
        {
            get { return count; }
        }

        public LListNode<T> Head
        {
            get { return head; }
        }
        #endregion

        #region Public Methods
        public void Enqueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            LListNode<T> result = new LListNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
            }
        }



        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("This queue is empty");
            return head.Value;
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            T item = head.Value;
            InternalRemoveNode(head);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }
        private void InternalRemoveNode(LListNode<T> node)
        {

            if (node.Next == node)
            {
                head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }
            count--;
            version++;
        }
        #endregion

        #region Private Methods
        private void InternalInsertNodeToEmptyList(LListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            count++;
            version++;
        }

        private void InternalInsertNodeBefore(LListNode<T> node, LListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            count++;
            version++;
        }
        #endregion

        #region Class QueueEnumerator
        class QueueEnumerator<T> : IEnumerator<T>
        {
            private int currentIndex = -1;
            private readonly LinkedListQueue<T> collection;
            private LListNode<T> node;
            private readonly int version;

            public QueueEnumerator(LinkedListQueue<T> collection)
            {
                this.collection = collection;
                node = collection.head;
                version = collection.version;
            }

            public bool MoveNext()
            {
                if (version != collection.version)
                {
                    throw new InvalidOperationException();
                }
                if (currentIndex++ != -1)
                    node = node.Next;
                return node != null;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.count)
                        throw new InvalidOperationException();
                    return node.item;
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
