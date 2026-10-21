using System;
using System.Threading.Channels;
using System.Threading.Tasks;

class ChannelPipelineDemo
{
    public record Item(int Id, string Payload);

    public static async Task Main()
    {
        var channel = Channel.CreateBounded<Item>(new BoundedChannelOptions(100) { SingleWriter = false, SingleReader = false });

        // Consumer
        var consumer = Task.Run(async () =>
        {
            await foreach (var item in channel.Reader.ReadAllAsync())
            {
                Console.WriteLine($"Consumed {item.Id}: {item.Payload}"); 
                await Task.Delay(20);
            }
        });

        // Producer
        for (int i = 0; i < 20; i++)
        {
            await channel.Writer.WriteAsync(new Item(i, $"p{i}"));
        }
        channel.Writer.Complete();

        await consumer;
    }
}
