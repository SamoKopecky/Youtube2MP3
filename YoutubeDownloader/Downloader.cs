using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace YoutubeDownloader
{
    public class Downloader
    {
        public string YoutubeDlPath { get; set; }
        public string FFmpegPath { get; set; }

        public Downloader()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                YoutubeDlPath = GetLinuxBinaryPath("youtube-dl");
                FFmpegPath = GetLinuxBinaryPath("ffmpeg");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // TODO: Windows finding of binaries
            }
            else
            {
                throw new Exception("No binaries found");
            }
        }

        private string GetLinuxBinaryPath(string binaryName)
        {
            var commonPath = $"/usr/bin/{binaryName}";
            if (File.Exists(commonPath))
            {
                return commonPath;
            }

            // TODO: Handling errors
            var whichCmd = ProcessRunner.RunProcess("/usr/bin/which", binaryName);
            return whichCmd;
        }


        public string DownloadSong(string url)
        {
            return ProcessRunner.RunProcess(YoutubeDlPath,
                $"{url} -x --ffmpeg-location {FFmpegPath} --audio-format mp3");
        }
    }
}