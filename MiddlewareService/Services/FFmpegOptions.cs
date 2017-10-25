using MiddlewareService.Data;

namespace MiddlewareService.Services
{
    class FFmpegOptions
    {
        private FFmpegMap fm = new FFmpegMap();
        public string audioCodec { get; set; }
        public string audioChannels { get; set; }
        public string audioSampling { get; set; }
        public string audioBitrate { get; set; }
        public string videoCodec { get; set; }
        public string videoBitrate { get; set; }

        public FFmpegOptions(Trabajo trabajo)
        {
            audioCodec = fm.audioCodec[trabajo.audioCodec];
            audioChannels = fm.audioChannels[trabajo.channels];
            audioSampling = fm.audioSampling[trabajo.sampling];
            audioBitrate = fm.audioBitrate[trabajo.audioBitRate];

            videoCodec = fm.videoCodec[trabajo.videoCodec];
            videoBitrate = fm.videoBitrate[trabajo.videoBitRate];
        }
    }
}
