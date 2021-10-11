using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
                YoutubeDlPath = GetWindowsBinaryPath("youtube-dl");
                FFmpegPath = GetWindowsBinaryPath("ffmpeg");
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
            return ProcessRunner.RunProcess("which", binaryName);
        }

        private string GetWindowsBinaryPath(string binaryName)
        {
            // TODO: Handling errors
            return ProcessRunner.RunProcess("where", binaryName).Trim();
        }

        public string DownloadSong(string url)
        {
            return ProcessRunner.RunProcess(YoutubeDlPath,
                $"{url} -x --ffmpeg-location {FFmpegPath} --audio-format mp3");
        }
    }
}