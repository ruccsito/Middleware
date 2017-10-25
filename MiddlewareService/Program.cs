using System.Threading;
using MiddlewareService.Data;
using MiddlewareService.Services;

namespace MiddlewareService
{
    class Program
    {
        private static Transcode transcode = new Transcode();
        private static TrabajosRepo tr = new TrabajosRepo();

        static void Main(string[] args)
        {
            // Traer de la DB el Trabajo, elegir el transcode y mandarle los datos de input, output y type.
            // Crear Transcode : ITranscode que reciba WFSService o FFMPEGService y llame a StartJob();    
            // Esperar y volver a buscar. 

            while (true)
            {
                var trabajos = tr.GetByStatus("Creado");

                foreach (var t in trabajos)
                {
                    switch (t.transcoder)
                    {
                        case "WFS":
                            transcode.Start(t, new WFSService());
                            break;

                        case "FFmpeg":
                            transcode.Start(t, new FFMPEGService());
                            break;

                        default:
                            break;
                    }
                }

                Thread.Sleep(10000); 
            }
        }
    }
}