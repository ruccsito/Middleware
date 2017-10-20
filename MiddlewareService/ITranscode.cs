using MiddlewareService.Data;

namespace MiddlewareService
{
    public interface ITranscode
    {
        void StartJob(Trabajo t);
    }
}
