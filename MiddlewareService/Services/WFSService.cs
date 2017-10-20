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

        private WfcJmServicesClient client;
        private TrabajosRepo tr;

        public void StartJob(Trabajo t)
        {
            tr = new TrabajosRepo();

            Console.WriteLine("Creando un job WFS para " + t.sourceFile);
            tr.UpdateStatus(t, "En proceso");

            // Do actual job.
            Thread.Sleep(60000);

            tr.UpdateStatus(t, "Completo");
            Console.WriteLine("Job completo para " + t.sourceFile + Environment.NewLine);
        }

        public void Real_StartJob(Trabajo t)
        {
            // Mod interface para que reciba el Trabajo trabajo.
            this.input = t.sourceFile;
            this.output = t.targetFile;
            client = new WfcJmServicesClient();

            var j = QueueJob();
            MonitorJob(j);

            // Queue the job. 
            // Monitor the new job. 
            // Update DB with job status. 

        }
        public Job QueueJob()
        {
            // Armar el workflow. Reemplazamos el path del destino en el XML.
            string workflowTemplate = @"C:\Users\julioar\DotNet\Middleware\MiddlewareService\SupportFiles\Workflow_Transcode.xml";
            string workflow = File.ReadAllText(workflowTemplate);
            workflow = workflow.Replace("%TRANSCODE_OUTPUT%", output);

            Job job = new Job();

            try
            {
                job = client.QueueJobByWorkflow(workflow.ToString(), input, output);

                // Alternative Solution: Store the workflow in WFS and queue it by referencing the workflow's Guid
                // var workflowGuid = StoreWorkflowTemplate(workflow, true); // store workflow template first
                // Queue a Job using workflowguid.
                // var job = _client.QueueJobByWorkflowGuid(workflowGuid, mediaAsset, output, SourceFileType.SingleFile); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to Queue Job." + Environment.NewLine + ex.Message);
                return null;
            }
            return job;
        }
        public void MonitorJob(Job job)
        {
            bool completed = false;
            while (!completed)
            {
                job = client.GetJob(job.Guid, true);

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
            }
        }


    }
}
