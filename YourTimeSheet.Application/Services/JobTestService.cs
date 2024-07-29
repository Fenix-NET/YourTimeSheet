using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Contracts;

namespace YourTimeSheet.Application.Services
{
    public class JobTestService : IJobTestService
    {
        public void FireAndForgetJob()
        {
            Console.WriteLine("Одноразовая задача запустил и забыл FireAndForgetJob");
        }
        public void ReccuringJob()
        {
            Console.WriteLine("Повторяющаяся задача ReccuringJob");
        }
        public void DelayedJob()
        {
            Console.WriteLine("Отложенная задача DelayedJob");
        }
        public void ContinuationJob()
        {
            Console.WriteLine("Последовательная задача ContinuationJob");
        }
    }
}
