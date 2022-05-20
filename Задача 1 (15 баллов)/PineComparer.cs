using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1__15_баллов_
{
    internal class PineComparer : IComparer<int[]>
    {
        public int Compare(int[] a1, int[] a2)
        {
            if (a1[0] < a2[0])
            {
                return 1;
            }
            else if (a1[0] > a2[0])
            {
                return -1;
            }
            if (a1[1] > a2[1])
            {
                return 1;
            }
            else if (a1[0] < a2[1])
            {
                return -1;
            }
            return 0;
        }
    }
}
