using System;
using YoutubeDownloader;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var downloader = new Downloader();
            downloader.DownloadSong("https://www.youtube.com/watch?v=3VGS7rRT8vg");
        }
    }
}