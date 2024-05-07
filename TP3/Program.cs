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
using System.Security.Cryptography.X509Certificates;
using System;

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
            #region testMusic.mp3
            //try
            //{
            //    Music music2 = new Music("fall-back.mp3", 666);

            //    music2.Player.settings.autoStart = false;
            //    music2.Player.URL = music2.Title;

            //    Console.WriteLine($"Press any key to start playing {music2.Title} ...");
            //    Console.ReadKey();

            //    music2.Play();

            //    Console.WriteLine("Press any key to stop playback and exit...");
            //    Console.ReadKey();

            //    music2.Stop();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            //}
            #endregion

            MediaPlayer mediaPlayer = new MediaPlayer();





            DisplayMainMenuOption();

            //Only create one media player
            //all method sould be inside media player

        }










        //Only if we have extra time
        public static string[] GetEnumStringValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetNames(typeof(TEnum));
        }
        public static int GetUserChoice(string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                Console.Clear();

                for (int i = 0; i < options.Count(); i++)
                {

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {


                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection - 1 < 0)
                            {
                                currentSelection = options.Count() - 1;
                            }
                            else
                            {
                                currentSelection--;
                            }

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + 1 > options.Count() - 1)
                            {
                                currentSelection = 0;
                            }
                            else
                            {
                                currentSelection++;
                            }

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            break;

                        }
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            return currentSelection;
        }

        public static void DisplayMenuPlayOption()
        {
            string[] optionsEnum = GetEnumStringValues<PlayOption>();
            int userchoice = GetUserChoice(optionsEnum);
            switch (userchoice)
            {
                case (int)PlayOption.Quit:
                    DisplayMenuPlaylistOption();
                    break;
                case (int)PlayOption.PlayNext:
                    break;
                case (int)PlayOption.PlayPrevious:
                    break;
                case (int)PlayOption.Stop:
                    break;
            }
        }
        public static void DisplayMenuPlaylistOption()
        {
            string[] optionsEnum = GetEnumStringValues<PlaylistOption>();
            int userchoice = GetUserChoice(optionsEnum);
            switch (userchoice)
            {
                case (int)PlaylistOption.Quit:
                    DisplayMainMenuOption();
                    break;

                case (int)PlaylistOption.PrintPlaylist:
                    break;
                case (int)PlaylistOption.AddMediaToPlaylist:
                    break;
                case (int)PlaylistOption.RemoveMediaFromPlaylist:
                    break;
                case (int)PlaylistOption.SortPlaylistByTitleAsc:
                    break;
                case (int)PlaylistOption.SortPlaylistByTitleDesc:
                    break;
                case (int)PlaylistOption.StartPlaylist:
                    DisplayMenuPlayOption();
                    break;

            }

        }
        public static void DisplayMainMenuOption()
        {
            string[] optionsEnum = GetEnumStringValues<MainMenuOption>();
            int userchoice = GetUserChoice(optionsEnum);
            switch (userchoice)
            {
                case (int)MainMenuOption.Quit:
                    GetQuitConfimation();
                    break;

                case (int)MainMenuOption.LoadMusics:

                    break;

                case (int)MainMenuOption.LoadVideos:
                    break;

                case (int)MainMenuOption.ManagePlaylist:
                    DisplayMenuPlaylistOption();
                    break;
            }
        }
        public static void GetQuitConfimation()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit the program?");
            string[] optionsEnum = GetEnumStringValues<Quit>();
            int userchoice = GetUserChoice(optionsEnum);

            switch (userchoice)
            {
                case (int)Quit.Yes:
                    break;
                case (int)Quit.No:
                    DisplayMainMenuOption();
                    break;
            }


        }
    }
}
