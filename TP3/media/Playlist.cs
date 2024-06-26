﻿using PROF.media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TP3.comparer;
using TP3.media;

namespace TP3.media
{
    //Tarik
    public class Playlist
    {
        private int currentMediaId;
        private IMediaComparer mediaComparer;
        private List<Media> medias;

        public int CurrentMediaId
        {
            get { return currentMediaId; }
            set { currentMediaId = value; }
        }

        public IMediaComparer MediaComparer
        {
            get { return mediaComparer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Le comparateur de média ne peut pas être nul.");
                }
                mediaComparer = value;
            }
        }

        public List<Media> Medias
        {
            get { return medias; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("La liste des médias ne peut pas être nulle.");
                }
                medias = value;
            }
        }

        public Playlist()
        {
            this.mediaComparer = new NoSortComparer();
            this.CurrentMediaId = 0;
            this.Medias = new List<Media>();
        }

        public void Sort(IMediaComparer comparer)
        {
            if (comparer != null)
            {
                IComparer<Media> mediaComparer = Comparer<Media>.Create((x, y) => comparer.Compare(x, y));

                Medias.Sort(mediaComparer);
            }
            else
            {
                throw new InvalidOperationException("Le comparateur de médias n'a pas été défini.");
            }
            this.mediaComparer = comparer;
        }


        public void Stop()
        {
            Media currentMedia = GetCurrentMedia();
            if (currentMedia != null)
            {
                currentMedia.Stop();
            }
        }

        public override string ToString()
        {
            string data = "Playlist content:\n\n";
            data += String.Format("{0,-4}{1,-26}{2,-5}", "###", "Titles", "Years");
            data += "\n";
            data += String.Format("{0,-4}{1,-26}{2,-5}", "===", "========================", "=====");
            foreach (Media media in medias)
            {
                data += "\n";
                data += String.Format("{0,-4}{1,-26}{2,-5}", medias.IndexOf(media) + 1, media.Title, media.Year);

            }
            data += "\n\n";
            return data;
        }

        public void AddMedia(Media newMedia)
        {
            if (newMedia == null)
            {
                throw new ArgumentNullException("Le média à ajouter ne peut pas être nul.");
            }

            Medias.Add(newMedia);
            Sort(this.MediaComparer);
        }

        public List<Media> FilterUnusedMedias(List<Media> allMedias)
        {
            if (allMedias == null)
            {
                throw new ArgumentNullException(nameof(allMedias), "La liste de tous les médias ne peut pas être nulle.");
            }
            List<Media> unusedMedias = new List<Media>();

            foreach (Media media in allMedias)
            {
                if (!Medias.Contains(media))
                {
                    unusedMedias.Add(media);
                }
            }

            return unusedMedias;
        }

        public Media GetCurrentMedia()
        {
            if (currentMediaId >= 0 && currentMediaId < Medias.Count)
            {
                return this.Medias[currentMediaId];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not good");
            }
        }

        public void PlayNext()
        {
            if (currentMediaId == Medias.Count - 1)
            {
                currentMediaId = 0;
            }
            else
            {
                currentMediaId++;
            }
        }

        public void PlayPrevious()
        {
            if (currentMediaId == 0)
            {
                currentMediaId = Medias.Count - 1;
            }
            else
            {
                currentMediaId--;
            }
        }

        public void RemoveMedia(int MediaId)
        {
            if (MediaId >= 0 && MediaId < Medias.Count)
            {
                Medias.RemoveAt(MediaId);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void RemoveMedia(Media media)
        {
            if (Medias.Contains(media))
            {
                Medias.Remove(media);
            }
        }

        public int Size()
        {
            return Medias.Count;
        }
    }
}
