using System.Threading.Tasks;
using MiddlewareService.Data;

namespace MiddlewareService
{
    public class Transcode
    {
        private ITranscode transcoder;

        public Transcode()
        {

        }

        public void Start(Trabajo t, ITranscode tr)
        {
            transcoder = tr;

            Task job = Task.Factory.StartNew( () => {
                    transcoder.StartJob(t);
                });

            job.Wait();
        }
    }
}
