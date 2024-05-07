﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.media;

namespace TP3.comparer
{
    public class TitleAscComparer : IMediaComparer
    {
        public int Compare(Media media1, Media media2)
        {
            if (media1 == null && media2 == null)
            {
                return 0;
            }
            else if (media1 == null)
            {
                return -1;
            }
            else if (media2 == null)
            {
                return 1;
            }
            else
            {
                return string.Compare(media1.Title, media2.Title);
            }
        }
    }

}
