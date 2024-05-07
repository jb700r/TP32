using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.media;

namespace TP3.comparer
{
    public class NoSortComparer : IMediaComparer
    {
        public int Compare(Media media1, Media media2)
        {
            if (media1 == null || media2 == null)
            {
                throw new ArgumentNullException("Aucune Playlist triée.");
            }
            else if (media1.Year > media2.Year)
            {
                return -1;
            }
            else if (media1.Year < media2.Year)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}

