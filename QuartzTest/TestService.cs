using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Test
{
    public class TestService : JobService<TestJob>
    {
        protected override string JobName => "测试作业中心";

        protected override string GroupName => "测试调度中心";

        protected override ITrigger GetTrigger()
        {
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(JobName, GroupName)
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();
            return trigger;
        }
    }
}
