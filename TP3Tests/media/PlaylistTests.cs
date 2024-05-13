using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3.media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.comparer;
using PROF.media;

namespace TP3.media.Tests
{
    [TestClass()]
    public class PlaylistTests
    {

        void ThisMethodeMUSTCompile()
        {
            Playlist playlist = new Playlist();
            playlist.GetCurrentMedia();
            playlist.Size();
            Media music = new Music("", 1229);
            playlist.AddMedia(music);
            playlist.RemoveMedia(0);
            playlist.PlayNext();
            playlist.PlayPrevious();

        }

        [TestMethod]
        public void PlaylistConstructTest()
        {
            Playlist playlist = new Playlist();

        }

        [TestMethod]
        public void AddMediaToPlaylist()
        {
            const int COUNT_MEDIA_LIST = 1;

            Playlist playlist = new Playlist();
            Media media = new Music("Test.mp3", 2024);

            playlist.AddMedia(media);

            Assert.AreEqual(COUNT_MEDIA_LIST, playlist.Medias.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullMediaToPlaylist()
        {
            Playlist playlist = new Playlist();
            Media media = null;

            playlist.AddMedia(media);
        }

        [TestMethod]
        public void RemoveMediaFromPlaylist()
        {
            const int COUNT_MEDIA_LIST = 0;

            Playlist playlist = new Playlist();
            Media media = new Music("Test.mp3", 2024);

            playlist.AddMedia(media);
            playlist.RemoveMedia(0);

            Assert.AreEqual(COUNT_MEDIA_LIST, playlist.Medias.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveMediaToPlaylistThatIsAlreadyEmpty()
        {
            Playlist playlist = new Playlist();

            playlist.RemoveMedia(0);
        }

        [TestMethod]
        public void GetSizeOfThePlaylist()
        {
            const int EXPECTED_SIZE = 4;
            Playlist playlist = new Playlist();

            Media music1 = new Music("music1.mp3", 2024);
            Media music2 = new Music("music2.mp3", 2024);
            Media music3 = new Music("music3.mp3", 2024);
            Media music4 = new Music("music4.mp3", 2024);

            playlist.AddMedia(music1);
            playlist.AddMedia(music2);
            playlist.AddMedia(music3);
            playlist.AddMedia(music4);

            Assert.AreEqual(EXPECTED_SIZE, playlist.Size());
        }

        [TestMethod]
        public void GetUnsusedMedia()
        {
            const int EXPECTED_COUNT = 3;
            Media music1 = new Music("music1.mp3", 2024);
            Media music2 = new Music("music2.mp3", 2024);
            Media music3 = new Music("music3.mp3", 2024);
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Medias.Add(music1);
            mediaPlayer.Medias.Add(music2);
            mediaPlayer.Medias.Add(music3);

            Playlist playlist = new();

            List<Media> unusedMedia = playlist.FilterUnusedMedias(mediaPlayer.Medias);

            Assert.AreEqual(EXPECTED_COUNT, unusedMedia.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUnsusedMediaFromNullMediaList()
        {

            List<Media> medias = null;
            Playlist playlist = new();

            List<Media> unusedMedia = playlist.FilterUnusedMedias(medias);
        }
        [TestMethod]
        public void GetCurrentMediaId()
        {
            Media music1 = new Music("music1.mp3", 2024);
            Media music2 = new Music("music2.mp3", 2024);
            Media music3 = new Music("music3.mp3", 2024);
            Playlist playlist = new Playlist();
            playlist.AddMedia(music1);
            playlist.AddMedia(music2);
            playlist.AddMedia(music3);



            playlist.CurrentMediaId = 1;

            Assert.AreEqual(music2, playlist.GetCurrentMedia());

        }
    }
}