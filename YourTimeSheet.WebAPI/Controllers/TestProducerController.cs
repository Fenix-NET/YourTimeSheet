using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.DataTransferObject;
using YourTimeSheet.Core.Entities;
using YourTimeSheet.SharedModels;

namespace YourTimeSheet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestProducerController :ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TestSheet testSheet { get; set; } = new TestSheet();

        public TestProducerController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            await _publishEndpoint.Publish<TestTaskCreated>(new
            {
                Id = new Guid(),

            });
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDto taskDto)
        {
            await _publishEndpoint.Publish<TestTaskCreated>(new
            {
                Id = new Guid(),
                taskDto.TaskName,

            });
            //string ww = "002929222223323";
            //await _publishEndpoint.Publish<TestTaskCreated>(ww);
            return Ok();
        }
    }
}
