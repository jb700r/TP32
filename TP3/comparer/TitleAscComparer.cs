using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.comparer
{
    public class TitleAscComparer : IMediaComparer
    {
        public int Compare(Media media1, Media media2)
        {
            return string.Compare(media1.Title, media2.Title);
        }
    }

}
