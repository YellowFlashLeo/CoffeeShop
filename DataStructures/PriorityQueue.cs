using System;
using System.Threading;

namespace DataStructures
{

    public class PriorityQueue
    {
        private int[] values = new int[5];
        private int count;

        public void Insert(int item)
        {          
            if (values.Length == count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int i;
                for  (i = count-1; i >= 0; i--)
                {
                    if (values[i] > item)
                    {
                        values[i + 1] = values[i];
                    //[1,3,5,7]   ->   [1,3,5,7,7]  -> [1,3,5,5,7] ... ->finally [1,2,3,5,7] if we inserted 2
                    }
                    else
                        break;
                }
            values[i + 1] = item;
            count++;
        }
       
    }
}
