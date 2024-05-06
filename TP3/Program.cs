using TP3.media;
using TP3.menu;
using TP3.comparer;
using System.Text;
using System.Diagnostics;
using WMPLib;
using System.Numerics;
using PROF.media;

using System.Threading;
using System.Runtime.CompilerServices;

namespace TP3
{
    public class Program
    {
        public const string SONGS_PLAYLIST_EXTENSION = "music";
        public const string SONGS_PLAYLIST_FILENAME = "Songs." + SONGS_PLAYLIST_EXTENSION;
        public const string VIDEO_PLAYLIST_EXTENSION = "video";
        public const string VIDEOS_PLAYLIST_FILENAME = "Videos." + VIDEO_PLAYLIST_EXTENSION;

        public static void Main(string[] args)
        {
            //Console.WriteLine("Your options are: ");
            //foreach (MainMenuOption option in Enum.GetValues(typeof(MainMenuOption)))
            //{
            //    Console.WriteLine(option);
            //}





            try
            {
                Music music2 = new Music("fall-back.mp3", 666);

                music2.Player.URL = music2.Title;

                music2.Play();

                Console.WriteLine("Press any key to stop playback and exit...");
                Console.ReadKey();

                music2.Stop();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }



        }
    }

}
