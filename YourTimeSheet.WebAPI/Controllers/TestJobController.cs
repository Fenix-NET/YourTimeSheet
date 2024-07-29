using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Contracts;

namespace YourTimeSheet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestJobController :ControllerBase
    {
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly IJobTestService _jobTestService;
        public TestJobController(IBackgroundJobService backgroundJobService, IJobTestService jobTestService)
        {
            _backgroundJobService = backgroundJobService;
            _jobTestService = jobTestService;
        }

        [HttpPost("enqueue")]
        public IActionResult EnqueueJob()
        {
            _backgroundJobService.Enqueue(() => _jobTestService.FireAndForgetJob());
            return Ok("Job enqueued, Одноразовая задача запустил и забыл FireAndForgetJob");
        }
        [HttpPost("delayed")]
        public IActionResult DelayedJob()
        {
            _backgroundJobService.Schedule(() => _jobTestService.ReccuringJob(), TimeSpan.FromMinutes(1));
            return Ok("delayedJob, Отложенная задача DelayedJob");
        }
        [HttpPost("reccuring")]
        public IActionResult ReccuringJob()
        {
            _backgroundJobService.AddOrUpdateRecurringJob("recurjob", () => _jobTestService.ReccuringJob(), Cron.Minutely());
            return Ok("ReccuringJob, Повторяющаяся задача ReccuringJob");
        }
    }
}
