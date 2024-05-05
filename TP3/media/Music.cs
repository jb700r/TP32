using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.media
{
    public class Music : Media
    {
        public void Play() { }
        public void Stop() { }

        public Music(string title, int year) : base(title, year)
        {

        }
    }
}
