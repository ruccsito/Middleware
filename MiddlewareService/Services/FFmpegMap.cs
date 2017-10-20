using System.Collections.Generic;

namespace MiddlewareService.Services
{
    class FFmpegMap
    {
        public Dictionary<string, string> audioCodec { get; set; }
        public Dictionary<string, string> audioBitrate { get; set; }
        public Dictionary<string, string> videoCodec { get; set; }
        public Dictionary<string, string> videoBitrate { get; set; }


        public FFmpegMap()
        {
            audioCodec = new Dictionary<string, string>();
            audioBitrate = new Dictionary<string, string>();
            videoCodec = new Dictionary<string, string>();
            videoBitrate = new Dictionary<string, string>();

            audioCodec.Add("AAC-LC", "aac");
            audioCodec.Add("AAC-HE", "aac");

            audioBitrate.Add("64", "64k");
            audioBitrate.Add("96", "96k");
            audioBitrate.Add("128", "126k");
            audioBitrate.Add("192", "192k");
            audioBitrate.Add("256", "256k");

            videoCodec.Add("H.264 AVC", "libx264");

            videoBitrate.Add("1000", "1M");
            videoBitrate.Add("2000", "2M");
            videoBitrate.Add("3000", "3M");
            videoBitrate.Add("8000", "8M");
            videoBitrate.Add("15000", "15M");
        }        
    }
}
