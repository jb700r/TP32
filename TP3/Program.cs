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
            const int QUIT = 0;
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
                                    Console.Clear();
                                    Console.WriteLine(mediaPlayer.CurrentPlaylist.ToString());
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    continue;
                                case (int)PlaylistOption.AddMediaToPlaylist:

                                    Console.Clear();
                                    userChoice = 0;
                                    bool success = false;
                                    List<Media> unusedMedia = mediaPlayer.CurrentPlaylist.FilterUnusedMedias(mediaPlayer.Medias);

                                    Console.Clear();
                                    success = false;


                                    do
                                    {
                                        int i = 1;
                                        Console.Clear();
                                        Console.WriteLine("ADD TO PLAYLIST \n\n");
                                        unusedMedia = mediaPlayer.CurrentPlaylist.FilterUnusedMedias(mediaPlayer.Medias);
                                        if (unusedMedia.Count() == 0)
                                        {
                                            Console.WriteLine("All media have been added to playlist. Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        Console.WriteLine("Available media :\n");
                                        foreach (Media unusedMediaItem in unusedMedia)
                                        {
                                            Console.WriteLine($"({i}) : {unusedMediaItem.ToString()}");
                                            i++;
                                        }
                                        Console.WriteLine("\n" + mediaPlayer.CurrentPlaylist.ToString() + "\n");

                                        Console.Write("Enter choice (0) to quit : ");
                                        success = int.TryParse(Console.ReadLine(), out userChoice);
                                        if (userChoice == 0)
                                        {
                                            Console.WriteLine("Quitting, Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        if (userChoice > 0 && userChoice <= unusedMedia.Count())
                                        {
                                            mediaPlayer.CurrentPlaylist.AddMedia(unusedMedia[userChoice - 1]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong input, Press any key to continue...");
                                            Console.ReadKey();
                                        }

                                    } while (true);



                                    continue;
                                case (int)PlaylistOption.RemoveMediaFromPlaylist:

                                    Console.Clear();
                                    do
                                    {
                                        int i = 1;
                                        Console.Clear();
                                        Console.WriteLine("REMOVE FROM PLAYLIST \n\n");
                                        if (mediaPlayer.CurrentPlaylist.Medias.Count() == 0)
                                        {
                                            Console.WriteLine("All media have been removed from the playlist. Press any key to continue...");
                                            break;
                                        }
                                        Console.WriteLine(mediaPlayer.CurrentPlaylist.ToString() + "\n");



                                        Console.Write("Enter choice (0) to quit : ");
                                        success = int.TryParse(Console.ReadLine(), out userChoice);
                                        if (userChoice == 0)
                                        {
                                            Console.WriteLine("Quitting, Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        if (userChoice > 0 && userChoice <= mediaPlayer.CurrentPlaylist.Medias.Count())
                                        {
                                            mediaPlayer.CurrentPlaylist.RemoveMedia(userChoice - 1);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong input, Press any key to continue...");
                                            Console.ReadKey();
                                        }

                                    } while (true);

                                    Console.ReadKey();
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
                                    if (mediaPlayer.CurrentPlaylist.Medias.Count() == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("No media to play. Press any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }
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

        public static string[] GetEnumStringValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetNames(typeof(TEnum));
        }
        public static int GetUserChoiceEnum(string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Use up and down arroy key to navigate and enter to select.\n");
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


    }
}
