using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Test
{
    public class JobManager
    {
        public void Start()
        {
            SchedulerBase.AddToScheduler(new TestService());

            SchedulerBase.Scheduler.Start();
        }

        public void Stop()
        {
            SchedulerBase.Scheduler.Shutdown(true);
        }
    }
}
