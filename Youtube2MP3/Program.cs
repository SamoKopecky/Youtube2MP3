using System;
using YoutubeDownloader;
using Mono.Options;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var url = ParseArguments(args);
            var downloader = new Downloader();
            var output = downloader.DownloadSong(url);
            Console.WriteLine(output);
        }

        private static string ParseArguments(string[] args)
        {
            var showHelp = false;
            var url = "";

            var set = new OptionSet()
            {
                {"u|url=", "url of the youtube video", v => url = v},
                {"h|help", "show this message and exit", v => showHelp = v != null}
            };

            try
            {
                var output = set.Parse(args);
            }
            catch (OptionException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again with --help option");
                Environment.Exit(1);
            }

            if (showHelp || url == "")
            {
                ShowHelp(set);
                Environment.Exit(0);
            }

            return url;
        }

        private static void ShowHelp(OptionSet set)
        {
            Console.WriteLine("Usage: YoutubeDownloader [OPTIONS]\n");
            Console.WriteLine("Download your favorite song\n");
            Console.WriteLine("Options:");
            set.WriteOptionDescriptions(Console.Out);
        }
    }
}