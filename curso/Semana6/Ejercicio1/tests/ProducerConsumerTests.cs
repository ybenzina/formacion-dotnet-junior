using System.Threading.Tasks;
using Xunit;

public class ProducerConsumerTests
{
    [Fact]
    public async Task MultipleProducersMultipleConsumers_TotalProducedEqualsTotalConsumed()
    {
        // 10 producers * 100 items = 1000 produced
        var result = await ProducerConsumer.RunProducersConsumersAsync(
            producerCount: 10,
            itemsPerProducer: 100,
            consumerCount: 5);

        Assert.Equal(1000, result.Produced);
        Assert.Equal(1000, result.Consumed);
    }

    [Fact]
    public async Task ConcurrentDictionary_ThousandTasksIncrementSameKey_FinalValueCorrect()
    {
        // 1000 tasks, cada uno se le incrementa su Key 100 veces -> esperado: 100_000
        int taskCount = 1000;
        int incrementsPerTask = 100;
        int expected = taskCount * incrementsPerTask;

        var final = await ProducerConsumer.ConcurrentDictionaryIncrementsAsync(
            key: "shared-key",
            taskCount: taskCount,
            incrementsPerTask: incrementsPerTask);

        Assert.Equal(expected, final);
    }
}
