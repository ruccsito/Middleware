using System.Collections.Generic;

namespace MiddlewareService.Services
{
    class FFmpegMap
    {
        public Dictionary<string, string> audioCodec { get; set; }
        public Dictionary<string, string> audioChannels { get; set; }
        public Dictionary<string, string> audioSampling { get; set; }

        public Dictionary<string, string> audioBitrate { get; set; }
        public Dictionary<string, string> videoCodec { get; set; }
        public Dictionary<string, string> videoBitrate { get; set; }




        public FFmpegMap()
        {
            audioCodec = new Dictionary<string, string>();
            audioChannels = new Dictionary<string, string>();
            audioSampling = new Dictionary<string, string>();

            audioBitrate = new Dictionary<string, string>();
            videoCodec = new Dictionary<string, string>();
            videoBitrate = new Dictionary<string, string>();

            audioCodec.Add("AAC-LC", "aac");
            audioCodec.Add("MP3", "mp3");
            audioCodec.Add("AC3", "ac3");
            audioCodec.Add("Vorbis", "libvorbis");

            audioChannels.Add("Stereo", "2");
            audioChannels.Add("5.1", "6");

            audioSampling.Add("22", "22100");
            audioSampling.Add("44", "44100");

            audioBitrate.Add("64", "64k");
            audioBitrate.Add("96", "96k");
            audioBitrate.Add("128", "126k");
            audioBitrate.Add("192", "192k");
            audioBitrate.Add("256", "256k");

            videoCodec.Add("H.264 AVC", "libx264 -x264-params \"nal-hrd=cbr\"");
            videoCodec.Add("VP9", "libvpx-vp9");

            videoBitrate.Add("1000", "1M");
            videoBitrate.Add("2000", "2M");
            videoBitrate.Add("3000", "3M");
            videoBitrate.Add("8000", "8M");
            videoBitrate.Add("15000", "15M");
        }        
    }
}
