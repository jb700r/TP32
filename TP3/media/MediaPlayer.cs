//using PROF.comparer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TP3.comparer;
using TP3.media;

namespace PROF.media
{
    public class MediaPlayer
    {
        private int currentMediaId;
        private Playlist currentPlaylist;
        private List<Media> medias;

        public int CurrentMediaId
        {
            get { return currentMediaId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("L'id du média ne peut pas être négatif.");
                }
                currentMediaId = value;
            }
        }

        public Playlist CurrentPlaylist
        {
            get { return currentPlaylist; }
            set
            {
                currentPlaylist = value;
            }
        }

        public List<Media> Medias
        {
            get { return medias; }
            private set { medias = value; }
        }


        public MediaPlayer()
        {
            medias = new List<Media>();
        }

        public void PlayNext()
        {
            if (currentPlaylist != null)
            {
                currentPlaylist.PlayNext();
            }
        }

        public void PlayPrevious()
        {
            if (currentPlaylist != null)
            {
                currentPlaylist.PlayPrevious();
            }
        }


        // prof
        // Ces méthodes vous sont fournies pour lire le contenu des fichiers songs.music et videos.video
        private static String GetFileExtension(String playlistName)
        {
            int dernierPointIndex = playlistName.LastIndexOf('.');

            // Vérifier si l'index est valide et obtenir l'extension
            if (dernierPointIndex > 0 && dernierPointIndex < playlistName.Length - 1)
            {
                return playlistName.Substring(dernierPointIndex + 1);
            }
            else
            {
                return ""; // Aucune extension trouvée ou le fichier commence par un point
            }
        }

        private List<string> ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8);
            List<string> listOfLines = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                listOfLines.Add(line);
            }

            return listOfLines;
        }


        // prof
        // Si vous avez respecté le diagramme de classes, vous n'avez qu'à décommenter la méthode suivante
        // pour lire tous les fichiers et remplir la liste de médias disponibles.
        public void LoadMedias(String medialistName)
        {
            /*
            medias = new List<Media>();
            currentMediaId = -1;
            String extension = GetFileExtension(medialistName);
            List <string> lignes = ReadFile(medialistName);


            foreach (string ligne in lignes)
            {

                if (extension.Equals(Program.SONGS_PLAYLIST_EXTENSION))
                {
                    String[] content = ligne.Split(",");
                    Music music = new Music(content[0], Int16.Parse(content[1]));
                    medias.Add(music);
                }
                else if (extension.Equals(Program.VIDEO_PLAYLIST_EXTENSION))
                {
                    String[] content = ligne.Split(",");
                    Video video = new Video(content[0], Int16.Parse(content[1]));

                    medias.Add(video);
                }

            }
            */
        }

        public Playlist GetPlaylist()
        {
            return currentPlaylist;
        }

        public Media GetUnusedMedia()
        {
            if (currentPlaylist != null)
            {
                List<Media> unusedMedias = currentPlaylist.FilterUnusedMedias(medias);
                return unusedMedias.Count > 0 ? unusedMedias[0] : null;
            }
            return null;
        }

        public void SortPlayList(IMediaComparer comparer)
        {
            if (currentPlaylist != null)
            {
                currentPlaylist.Sort(comparer);
            }
            else
            {
                throw new InvalidOperationException("Aucune playlist n'est définie.");
            }
        }

        public void Stop()
        {
            if (currentPlaylist != null)
            {
                currentPlaylist.Stop();
            }
        }

        public void WriteFile(string fileName, string[] linesToWrite)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string line in linesToWrite)
                {
                    writer.WriteLine(line);
                }
            }
        }

    }
}


