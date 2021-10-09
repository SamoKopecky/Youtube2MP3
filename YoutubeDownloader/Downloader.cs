using System.Diagnostics;
using System.Runtime.InteropServices;

namespace YoutubeDownloader
{
    public class Downloader
    {
        public void DownloadSong(string url)
        {
            var process = new Process();
            var youtubeDlName = "";
            var ffmpegName = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                youtubeDlName = "./binaries/linux/youtube-dl";
                ffmpegName = "./binaries/linux/ffmpeg";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                youtubeDlName = "./binaries/windows/youtube-dl.exe";
                ffmpegName = "./binaries/windows/ffmpeg.exe";
            }
            process.StartInfo.FileName = youtubeDlName;
            process.StartInfo.Arguments = $"{url} -x --ffmpeg-location {ffmpegName} --audio-format mp3";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
    }
}