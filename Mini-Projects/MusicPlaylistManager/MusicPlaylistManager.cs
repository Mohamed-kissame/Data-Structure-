using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistManager
{
    public class MusicPlaylistManager
    {

        private LinkedList<string> _Songs;

        public MusicPlaylistManager()
        {
            _Songs = new LinkedList<string>();

        }

        public void AddSongFirst(string songName)
        {

            if (String.IsNullOrWhiteSpace(songName))
            {
                Console.WriteLine("Enter an valid the Song Title");
                return;
            }

            _Songs.AddFirst(songName);

        }

        public void AddSongLast(string songName)
        {

            if (String.IsNullOrWhiteSpace(songName))
            {
                Console.WriteLine("Enter an valid the Song Title");
                return;
            }

            _Songs.AddLast(songName);


        }

        public void InsertSongAfter(string existingSong, string newSong)
        {

            if (String.IsNullOrWhiteSpace(newSong))
            {
                Console.WriteLine("Enter a valid the Song Title");
                return;
            }

            if (String.IsNullOrWhiteSpace(existingSong))
            {
                Console.WriteLine("Enter a valid existing song title");
                return;
            }

            _Songs.InsertAfter(existingSong, newSong);

        }

        public void RemoveSong(string songName)
        {


            if (String.IsNullOrWhiteSpace(songName))
            {
                Console.WriteLine("Enter an valid the Song Title");
                return;
            }

            if (_Songs.Count == 0) { Console.WriteLine("No songs in this playlist to delete"); return; }

            _Songs.Delete(songName);

        }

        public bool ContainsSong(string songName)
        {
            if (String.IsNullOrWhiteSpace(songName))
                return false;

            return _Songs.Contains(songName);
        }

        public void ShowPlaylist()
        {

            if(_Songs.Count == 0) { Console.WriteLine("No songs in this playlist"); return; }

            _Songs.Display();

        }


    }
}
