using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPFSample.DTO;

namespace WPFSample.Utils
{
    public class TimeComparer : IComparer<Time>
    {
        public int Compare(Time x, Time y)
        {
            if( ( x == null ) || ( y == null ) )
            {
                throw new ArgumentException();
            }
            else
            {
                if( x.Hours != y.Hours )
                {
                    return x.Hours.CompareTo(y.Hours);
                }
                else
                {
                    return x.Minutes.CompareTo(y.Minutes);
                }
            }
        }
    }
}
