using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeSheet.Core.Contracts
{
    public interface IBackgroundJobService
    {
        void Enqueue(Expression<Action> methodCall);
        void Schedule(Expression<Action> methodCall, TimeSpan delay);
        void AddOrUpdateRecurringJob(string jobName, Expression<Action> methodCall, string cron);
    }
}
