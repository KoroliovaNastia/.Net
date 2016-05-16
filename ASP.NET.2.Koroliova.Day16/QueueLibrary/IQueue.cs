using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibrary
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Peek();
        T Dequeue();
    }
}
