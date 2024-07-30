using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.SharedModels;

namespace YourTimeSheet.Consumer
{
    public class TaskCreatedConsumer : IConsumer<TestTaskCreated>
    {
        public async Task Consume(ConsumeContext<TestTaskCreated> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"TaskCreated message: {jsonMessage}");
        }
    }
}
