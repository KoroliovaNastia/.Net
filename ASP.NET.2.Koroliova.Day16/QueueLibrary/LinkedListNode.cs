using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QueueLibrary
{
    public sealed class LListNode<T>
    {
        internal LinkedListQueue<T> list;
        internal LListNode<T> next;
        internal LListNode<T> prev;
        internal T item;

        #region Ctors
        public LListNode(T value)
        {
            this.item = value;
        }

        internal LListNode(LinkedListQueue<T> list, T value)
        {
            this.list = list;
            this.item = value;
        }
        #endregion

        #region Fields
        public LinkedListQueue<T> List
        {
            get { return list; }
        }

        public LListNode<T> Next
        {
            get { return next == null || next == list.Head ? null : next; }
        }

        public LListNode<T> Previous
        {
            get { return prev == null || this == list.Head ? null : prev; }
        }

        public T Value
        {
            get { return item; }
            set { item = value; }
        }
        #endregion
    }
}
