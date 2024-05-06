using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.comparer;

namespace TP3.media
{
    public class Video : Media
    {
        public override void Play() { }
        public override void Stop() { }

        public Video(string title, int year) : base(title, year)
        {

        }
    }
}
