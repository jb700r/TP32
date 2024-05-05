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
        public void Play() { }
        public void Stop() { }

        public Video(string title,int year) : base(title,year)
        {
  
        }
    }
}
