using PROF.comparer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROF.media
{
    public class MediaPlayer
    {

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

            currentMediaId = 0;
            */
        }
    }
}


