using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace TP3.media
{
    public abstract class Media : IPlayable
    {
        private string title;
        private int year;
        private WindowsMediaPlayer player;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public WindowsMediaPlayer Player
        {
            get { return player; }
            set { player = value; }
        }

        public Media(string title,int year) 
        {
            this.Title = title;
            this.Year = year;
        }

        public void Play() { }
        public void Stop() { }

        public override bool Equals(object obj)
        {
            if ( ((Media)obj).Title == this.Title && ((Media)obj).Year == this.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{this.Title} from ({this.Year})";
        }
    }
}
