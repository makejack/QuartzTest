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
    public class SchedulerBase
    {

        private static IScheduler m_scheduler;
        public static IScheduler Scheduler
        {
            get
            {
                if (m_scheduler != null)
                {
                    return m_scheduler;
                }

                InstanceScheduler();

                return m_scheduler;
            }
        }

        private async static void InstanceScheduler()
        {
            NameValueCollection props = new NameValueCollection
            {
                {"Quartz.Serializer.Name","作业调度中心" }
            };

            ISchedulerFactory factory = new StdSchedulerFactory(props);
            m_scheduler = await factory.GetScheduler();
        }

        public static void AddToScheduler<T>(JobService<T> service) where T : IJob
        {
            service.AddJobToScheduler(Scheduler);
        }
    }
}
