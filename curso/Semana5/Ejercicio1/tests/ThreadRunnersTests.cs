using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ThreadVsTask.Tests
{
    public class ThreadRunnersTests
    {
        private readonly ThreadRunners _runners = new ThreadRunners();
        private readonly ITestOutputHelper _output;
        private const int TestIterations = 10;

        public ThreadRunnersTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task TasksAndThreads_ShouldReturnSameTotal()
        {
            var cts = new CancellationTokenSource();

            var tasksResult = await _runners.RunnerTasks(TestIterations, cts.Token);
            var threadsResult = _runners.RunnerThreads(TestIterations);
            var backgroundThreadsResult = _runners.RunnerBackgroundThreads(TestIterations);
            var threadPoolResult = _runners.RunnerThreadPool(TestIterations);

            Assert.Equal(threadsResult, tasksResult);
            Assert.Equal(threadsResult, backgroundThreadsResult);
            Assert.Equal(threadsResult, threadPoolResult);
        }

        [Fact]
        public async Task RunnerTasks_Cancels()
        {
            var cts = new CancellationTokenSource();
            var task = _runners.RunnerTasks(1000, cts.Token);
            
            cts.Cancel();

            await Assert.ThrowsAnyAsync<OperationCanceledException>(() => task);
        }

        [Fact]
        public async Task ComparePerformance()
        {
            var n = 1000;
            var cts = new CancellationTokenSource();

            var threadTime = _runners.MeasureTime(() => _runners.RunnerThreads(n));
            var backgroundThreadTime = _runners.MeasureTime(() => _runners.RunnerBackgroundThreads(n));
            var threadPoolTime = _runners.MeasureTime(() => _runners.RunnerThreadPool(n));
            var taskTime = await _runners.MeasureTimeAsync(async () => await _runners.RunnerTasks(n, cts.Token));

            _output.WriteLine($"Thread time: {threadTime.TotalMilliseconds}ms");
            _output.WriteLine($"Background Thread time: {backgroundThreadTime.TotalMilliseconds}ms");
            _output.WriteLine($"ThreadPool time: {threadPoolTime.TotalMilliseconds}ms");
            _output.WriteLine($"Task time: {taskTime.TotalMilliseconds}ms");
        }
    }
}
