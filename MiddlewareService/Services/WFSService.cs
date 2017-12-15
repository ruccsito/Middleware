using System;
using System.IO;
using System.Threading;
using MiddlewareService.Data;
using MiddlewareService.Service_References.WfsServiceReference;

namespace MiddlewareService.Services
{
    class WFSService : ITranscode
    {
        private string input;
        private string output;
        private string guid; 

        private WfcJmServicesClient client;
        private TrabajosRepo tr;

        public void StartJob(Trabajo t)
        {
            tr = new TrabajosRepo();

            Console.WriteLine("Creando un job WFS para " + t.sourceFile);
            tr.UpdateStatus(t, "En proceso");

            // Do actual job.
            client = new WfcJmServicesClient();
            input = t.sourceFile;
            output =t.targetFile;
            
            guid = this.GetGuid(t);

            var j = QueueJob(guid, input, output);
            string result = MonitorJob(j);

            tr.UpdateStatus(t, result);
            Console.WriteLine("Job completo para " + t.sourceFile + Environment.NewLine);
        }
        public Job QueueJob(string guid, string input, string output)
        {
            string workflowTemplate = @"\\filesba.foxinc.com\Transfer\J-ARNEDO\WorkflowTemplate.xml";
            string workflow = File.ReadAllText(workflowTemplate);
            workflow = workflow.Replace("%OUTPUTPATH%", Path.GetDirectoryName(output));
            workflow = workflow.Replace("%FILENAME%", Path.GetFileName(output));
            workflow = workflow.Replace("%GUID%", guid);

            Job job = new Job();

            try
            {
                job = client.QueueJobByWorkflow(workflow, input, Path.GetDirectoryName(output)); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Queue Job." + Environment.NewLine + ex.Message);
                return null;
            }
            return job;
        }
        public string MonitorJob(Job job)
        {
            int check = 0;
            while (check < 20)
            {
                job = client.GetJob(job.Guid, true);

                if (job.Status == JobStatus.Completed || job.Status == JobStatus.Fatal)
                    return "Completed";

                if (job.Status == JobStatus.Fatal)
                    return "Failed";

                Console.WriteLine("Checking " + check);
                Console.WriteLine("Status : " + job.Status);
                Console.WriteLine("Tasks : " + job.Task.Length);
                int c = 0;

                foreach (var task in job.Task)
                {
                    Console.WriteLine("Task " + c + " status: " + task.TaskStatus);
                    c += 1;
                }
                Thread.Sleep(20000);
                Console.Clear();
                check += 1;                
            }

            return "Not responding";
        }
        public string GetGuid(Trabajo t)
        {
            // TODO: Reglas para switchear el GUID. 
            return "{1d11b778-7631-41dd-9a20-16926403beb9}";
        }
    }
}
