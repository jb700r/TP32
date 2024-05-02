using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.media
{
    public interface IMediaComparer
    {
        int Compare(Media media1, Media media2);
    }
}
