using TP3.media;
using TP3.menu;
using TP3.comparer;
using System.Text;
using System.Diagnostics;
using WMPLib;
using System.Numerics;

namespace TP3
{
    internal class Program
    {
        public const string SONGS_PLAYLIST_EXTENSION = "music";
        public const string SONGS_PLAYLIST_FILENAME = "Songs." + SONGS_PLAYLIST_EXTENSION;
        public const string VIDEO_PLAYLIST_EXTENSION = "video";
        public const string VIDEOS_PLAYLIST_FILENAME = "Videos." + VIDEO_PLAYLIST_EXTENSION;

        public static void Main(string[] args)
        {
            Console.WriteLine("Your options are: ");
            foreach (MainMenuOption option in Enum.GetValues(typeof(MainMenuOption))) 
                {
                Console.WriteLine(option);
            }

        }
    }

}
