using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Test
{
    public abstract class JobService<T> where T : IJob
    {
        protected abstract string JobName { get; }

        protected abstract string GroupName { get; }

        private IJobDetail GetJobDetail()
        {
            IJobDetail job = JobBuilder.Create<T>().WithIdentity(JobName, GroupName).Build();
            return job;
        }

        protected abstract ITrigger GetTrigger();

        public void AddJobToScheduler(IScheduler scheduler)
        {
            scheduler.ScheduleJob(GetJobDetail(), GetTrigger());
        }
    }
}
