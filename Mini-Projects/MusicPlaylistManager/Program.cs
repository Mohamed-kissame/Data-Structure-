using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistManager
{
    public class Program
    {
        static void Main(string[] args)
        {

            MusicPlaylistManager playlistManager = new MusicPlaylistManager();

            playlistManager.AddSongLast("Song A");
            playlistManager.AddSongLast("Song B");
            playlistManager.AddSongLast("Song C");

            playlistManager.ShowPlaylist();

            playlistManager.RemoveSong("Song C");

            Console.WriteLine("\nAfter Remove Song C From the PlayList : ");

            playlistManager.ShowPlaylist();

            playlistManager.InsertSongAfter("Song B", "Song C");

            Console.WriteLine("\nAfter Insert After Song B the Song C Now the PlayList come with those songs : ");

            playlistManager.ShowPlaylist();


        }
    }
}
