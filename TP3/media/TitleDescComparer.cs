using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.media
{
    public class TitleDescComparer : IMediaComparer
    {
        public int Compare(Media media1, Media media2)
        {
            return string.Compare(media2.Title, media1.Title);
        }
    }

}
