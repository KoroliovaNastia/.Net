using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearch
{
    public class SearchMass<T> where T : IComparable
    {
        public static int Search(T[] mass, T x, Comparer<T> comparer)
        {
            if(mass==null)
                throw new NullReferenceException();
            if (mass.Length == 0)
                return -1;
            
            if(comparer==null)
                comparer=Comparer<T>.Default;
            if(!IsSorted(mass,comparer))
                throw new ArgumentException();
            if (comparer.Compare(x, mass[mass.Length-1]) > 0)
                return -1;
            if (comparer.Compare(x, mass[0]) < 0)
                return -1;

            return Search(mass, x, 0,mass.Length-1,comparer);
        }

        private static int Search(T[] mass, T x, int lhs, int rhs, Comparer<T> comparer)
        {

            if (lhs > rhs)
                return -1;
            int mid = lhs + (rhs - lhs) / 2;
            T psevdo = mass[mid];
            
            if (comparer.Compare(x, mass[lhs]) == 0)
                return lhs;
            if (comparer.Compare(x,psevdo)==0)
                if (mid == lhs + 1)
                {
                    return mid;
                }
                else
                {
                    return Search(mass,x,lhs,mid+1,comparer);
                }
            
            if(comparer.Compare(x,psevdo)<0)
                return Search(mass, x, lhs, mid - 1,comparer);
           
            if(comparer.Compare(x,psevdo)>0)
                return Search(mass, x, mid + 1, rhs,comparer);
            return -1;
        }

        private static bool IsSorted(T[] mass, Comparer<T> comparer)
        {
            bool temp = true;
            for(int i=1;i<mass.Length;i++)
                if (comparer.Compare(mass[i - 1], mass[i]) > 0)
                    temp = false;
            return temp;
        }
    }


}
