using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            JobManager job = new JobManager();
            job.Start();

            Wait(job);


            Console.WriteLine("press any key to close the application");
            Console.ReadKey();


        }

        private async static void Wait(JobManager job)
        {
            await Task.Delay(TimeSpan.FromSeconds(60));
            job.Stop();
            await Console.Out.WriteLineAsync("wait over");
        }

    }
}
