using System;
using System.IO;
using EmergenceGuardian.FFmpeg;
using MiddlewareService.Data;

namespace MiddlewareService.Services
{
    public class FFMPEGService : ITranscode
    {
        public void StartJob(Trabajo t)
        {
            //Crear Task que ejecute el FFMPEG
            //Poner el job en "En Proceso"
            //Esperar que termine la task, buscar la forma de evaluar la salida y actualizar de nuevo el job con Completo o Fallido

            CompletionStatus status = new CompletionStatus();
            TrabajosRepo tr = new TrabajosRepo();

            try
            {
                FFmpegConfig.FFmpegPath = @"C:\Sandbox\ffmpeg.exe";
                FFmpegOptions fo = new FFmpegOptions(t);

                if (File.Exists(t.targetFile))
                        File.Delete(t.targetFile);

                string parameters = string.Format(@"-i {0} -vf scale={1}:{2} -acodec {3} -ac {4} -ar {5} -ab {6} -vcodec {7} -b:v {8} -minrate {8} -maxrate {8} -f {9} {10}", 
                                                    t.sourceFile, t.width, t.height, fo.audioCodec, fo.audioChannels, fo.audioSampling, fo.audioBitrate, fo.videoCodec, fo.videoBitrate, t.container ,t.targetFile);

                Console.WriteLine("Creando un job FFMPEG para " + t.sourceFile);
                tr.UpdateStatus(t, "En proceso");

                FFmpegProcess f = new FFmpegProcess();
                status = f.RunFFmpeg(parameters);
            }

            catch (Exception e)
            {
                File.AppendAllText(@"C:\sandbox\log.txt", e.Message + Environment.NewLine);
                Console.WriteLine("Failed to process " + t.sourceFile + Environment.NewLine);
            }

            tr.UpdateStatus(t, (status == CompletionStatus.Success) ? "Completo" : "Error");

            Console.WriteLine("Job completo para " + t.sourceFile + Environment.NewLine);
        }
    }
}
