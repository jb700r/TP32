using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.comparer
{
    public class YearAscComparer : IMediaComparer
    {
        public int Compare(Media media1, Media media2)
        {
            return media1.Year.CompareTo(media2.Year);
        }
    }

}
