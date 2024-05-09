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
            //    Music music2 = new Music("bomboclat.mp3", 666);

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


            //MediaPlayer mediaPlayer = new MediaPlayer();
            //mediaPlayer.LoadMedias(SONGS_PLAYLIST_FILENAME);

            //foreach (Media media in mediaPlayer.Medias)
            //{
            //    Console.WriteLine(media);
            //}
            //Console.WriteLine(mediaPlayer.Medias[1]);

            //mediaPlayer.CurrentPlaylist.Medias.Add(mediaPlayer.Medias[0]);
            //mediaPlayer.CurrentPlaylist.Medias.Add(mediaPlayer.Medias[1]);


            //foreach (Media media in mediaPlayer.CurrentPlaylist.Medias)
            //{
            //    Console.WriteLine(media);
            //}
            //mediaPlayer.CurrentPlaylist.Medias[0].Player.URL = mediaPlayer.CurrentPlaylist.Medias[0].Title;

            //Console.WriteLine(mediaPlayer.CurrentPlaylist.Medias[0].Player.URL);

            //mediaPlayer.CurrentPlaylist.Medias[0].Player.settings.autoStart = false;

            //mediaPlayer.CurrentPlaylist.Medias[0].Play();



            //Main Menu


            //DisplayMainMenuOption();

            string[] options;
            int userChoice;
            MediaPlayer mediaPlayer = new MediaPlayer();
            bool quitMain = false;
            bool quitPlaylist = false;
            bool quitPlay = false;
            int currentMediaId = 0;
            YearAscComparer yearAscComparer = new();
            YearDescComparer yearDescComparer = new();
            TitleAscComparer titleAscComparer = new();
            TitleDescComparer titleDescComparer = new();

            do

            {
                quitMain = false;
                userChoice = GetUserChoiceEnum(GetEnumStringValues<MainMenuOption>());
                switch (userChoice)
                {
                    case (int)MainMenuOption.Quit:
                        quitMain = true;
                        break;
                    case (int)MainMenuOption.LoadMusics:
                        mediaPlayer.LoadMedias(SONGS_PLAYLIST_FILENAME);
                        continue;
                    case (int)MainMenuOption.LoadVideos:
                        mediaPlayer.LoadMedias(VIDEOS_PLAYLIST_FILENAME);
                        continue;
                    case (int)MainMenuOption.ManagePlaylist:
                        do
                        {
                            quitPlaylist = false;
                            userChoice = GetUserChoiceEnum(GetEnumStringValues<PlaylistOption>());
                            switch (userChoice)
                            {
                                case (int)PlaylistOption.Quit:
                                    quitPlaylist = true;
                                    break;
                                case (int)PlaylistOption.PrintPlaylist:
                                    Console.WriteLine(mediaPlayer.CurrentPlaylist.ToString());
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    continue;
                                case (int)PlaylistOption.AddMediaToPlaylist:
                                    mediaPlayer.CurrentPlaylist.AddMedia(mediaPlayer.Medias[0]);
                                    mediaPlayer.CurrentPlaylist.AddMedia(mediaPlayer.Medias[1]);
                                    mediaPlayer.CurrentPlaylist.AddMedia(mediaPlayer.Medias[2]);
                                    mediaPlayer.CurrentPlaylist.AddMedia(mediaPlayer.Medias[3]);
                                    continue;
                                case (int)PlaylistOption.RemoveMediaFromPlaylist:
                                    continue;
                                case (int)PlaylistOption.SortPlaylistByTitleAsc:
                                    mediaPlayer.CurrentPlaylist.Sort(titleAscComparer);
                                    
                                    continue;
                                case (int)PlaylistOption.SortPlaylistByTitleDesc:
                                    mediaPlayer.CurrentPlaylist.Sort(titleDescComparer);
                                    continue;
                                case (int)PlaylistOption.SortPlaylistByYearAsc:
                                    mediaPlayer.CurrentPlaylist.Sort(yearAscComparer);
                                    continue;
                                case (int)PlaylistOption.SortPlaylistByYearDesc:
                                    mediaPlayer.CurrentPlaylist.Sort(yearDescComparer);
                                    continue;
                               
                                case (int)PlaylistOption.StartPlaylist:
                                    mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Player.URL = mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Title;
                                    mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Play();
                                    do
                                    {
                                        quitPlay = false;
                                        userChoice = GetUserChoiceEnum(GetEnumStringValues<PlayOption>());
                                        switch (userChoice)
                                        {
                                            case (int)PlayOption.Quit:
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Stop();
                                                quitPlay = true;
                                                break;
                                            case (int)PlayOption.PlayNext:
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Stop();
                                                mediaPlayer.CurrentPlaylist.PlayNext();
                                                currentMediaId = mediaPlayer.CurrentPlaylist.CurrentMediaId;
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Player.URL = mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Title;
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Play();
                                                continue;
                                            case (int)PlayOption.PlayPrevious:
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Stop();
                                                mediaPlayer.CurrentPlaylist.PlayPrevious();
                                                currentMediaId = mediaPlayer.CurrentPlaylist.CurrentMediaId;
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Player.URL = mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Title;
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Play();
                                                continue;
                                            case (int)PlayOption.Stop:
                                                mediaPlayer.CurrentPlaylist.Medias[currentMediaId].Stop();
                                                continue;
                                        }
                                    } while (!quitPlay);
                                    continue;
                            }
                        } while (!quitPlaylist);


                        continue;
                }
            } while (!quitMain);

        }










        //Only if we have extra time
        public static string[] GetEnumStringValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetNames(typeof(TEnum));
        }
        public static int GetUserChoice(string[] options)
        {
            bool success = false;
            int choice = -1;

            do
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"({i}) {options[i]}");
                }

                Console.Write("Enter choice : ");
                success = int.TryParse(Console.ReadLine(), out choice);
                if (choice < 0 || choice > options.Length - 1)
                {
                    success = false;
                }
            } while (!success);
            return choice;
        }
        public static int GetUserChoiceEnum(string[] options)
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
            int userchoice = GetUserChoiceEnum(optionsEnum);
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
            int userchoice = GetUserChoiceEnum(optionsEnum);
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
            int userchoice = GetUserChoiceEnum(optionsEnum);
            switch (userchoice)
            {
                case (int)MainMenuOption.Quit:
                    GetQuitConfimation();
                    break;

                case (int)MainMenuOption.LoadMusics:

                    DisplayMainMenuOption();

                    break;

                case (int)MainMenuOption.LoadVideos:

                    DisplayMainMenuOption();


                    break;

                case (int)MainMenuOption.ManagePlaylist:
                    DisplayMenuPlaylistOption();
                    break;
            }
        }
        public static void GetQuitConfimation()
        {
            Console.Clear();

            string[] optionsEnum = GetEnumStringValues<Quit>();
            Console.Title = "QUIT???";
            int userchoice = GetUserChoiceEnum(optionsEnum);

            switch (userchoice)
            {
                case (int)Quit.Yes:
                    break;
                case (int)Quit.No:
                    DisplayMainMenuOption();
                    break;
            }


        }
        public static void AddMediaToPlaylist(MediaPlayer mediaPlayer)
        {

        }
        public static void RemoveMediaFromPlaylist() 
        {
        
        }

    }
}
