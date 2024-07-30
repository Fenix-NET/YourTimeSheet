
using MassTransit;
using YourTimeSheet.Consumer;

Console.WriteLine("Hello, World!");
var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("task-created-event", e =>
    {
        e.Consumer<TaskCreatedConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}