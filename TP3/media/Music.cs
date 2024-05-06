using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace TP3.media
{
    public class Music : Media
    {
        public override void Play()
        {
            this.Player.controls.play();
        }
        public override void Stop()
        {
            this.Player.controls.stop();
        }

        public Music(string title, int year) : base(title, year)
        {
            Player = new WindowsMediaPlayer();
        }
    }
}
