using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Contracts;

namespace YourTimeSheet.Infrastructure.Services
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IRecurringJobManager _jobManager;
        public BackgroundJobService(IRecurringJobManager jobManager)
        {
            _jobManager = jobManager ?? throw new ArgumentNullException();
        }
        public void Enqueue(Expression<Action> methodCall)
        {
            BackgroundJob.Enqueue(methodCall);
        }
        public void Schedule(Expression<Action> methodCall, TimeSpan delay)
        {
            BackgroundJob.Schedule(methodCall, delay);
        }
        public void AddOrUpdateRecurringJob(string jobName, Expression<Action> methodCall, string cron)
        {
            _jobManager.AddOrUpdate(jobName, methodCall, cron);
        }

    }
}
