using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Sequence
    {
        /// <summary>
        /// Enumerator which return elemen of sequence
        /// </summary>
        /// <param name="number">Count of sequence</param>
        /// <param name="enumerableSequence">Enumerator</param>
        /// <returns></returns>
        public static IEnumerable<long> GetSequence(int number, IEnumerable<long> enumerableSequence = null)
        {
            if (number < 0)
                throw new ArgumentNullException();
            if (enumerableSequence == null)

                return Fibonacci().Take(number);
            return enumerableSequence.Take(number);
        }
        /// <summary>
        /// Enumerator which return fibonacci number
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<long> Fibonacci()
        {

            long prev = 0;
            long next = 1;
            for (; ; )
            {

                long sum = prev + next;
                if (sum < prev)
                    yield break;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}
