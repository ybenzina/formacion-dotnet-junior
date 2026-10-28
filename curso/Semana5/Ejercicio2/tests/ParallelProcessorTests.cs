// Copyright (c) DrissBeGo 2025.  All rights reserved.

using Xunit.Abstractions;

namespace ParallelProcessing.Tests
{
	public class ParallelProcessorTests
	{
		private readonly ParallelProcessor _processor;
		private readonly ITestOutputHelper _output;

		public ParallelProcessorTests(ITestOutputHelper output)
		{
			_processor = new ParallelProcessor();
			_output = output;
		}

		[Theory]
		[InlineData(10_000)]    // 10k elementos
		[InlineData(100_000)]   // 100k elementos
		[InlineData(300_000)] // 300k elementos
		public void ShouldReturnSameResult(int n)
		{
			var items = new int[n];
			for (int i = 0; i < n; i++) items[i] = i;

			var sequentialResult = _processor.ProcessSequential(items);
			var parallelForEachResult = _processor.ProcessParallelForEach(items);
			var parallelForResult = _processor.ProcessParallelFor(items);
			var plinqResult = _processor.ProcessPLINQ(items);

			Assert.Equal(sequentialResult, parallelForEachResult);
			Assert.Equal(sequentialResult, parallelForResult);
			Assert.Equal(sequentialResult, plinqResult);
		}

		[Theory]
		[InlineData(10_000)]    // 10k elementos
		[InlineData(100_000)]   // 100k elementos
		[InlineData(300_000)] // 300k elementos
		public void ComparePerformance(int n)
		{
			var items = new int[n];
			for (int i = 0; i < n; i++) items[i] = i;

			var sequentialTime = _processor.MeasureTime(() => _processor.ProcessSequential(items));
			var parallelForEachTime = _processor.MeasureTime(() => _processor.ProcessParallelForEach(items));
			var parallelForTime = _processor.MeasureTime(() => _processor.ProcessParallelFor(items));
			var plinqTime = _processor.MeasureTime(() => _processor.ProcessPLINQ(items));

			_output.WriteLine($"\nResultados para n = {n:N0}:");
			_output.WriteLine($"Sequential:      {sequentialTime.TotalMilliseconds:N2}ms");
			_output.WriteLine($"Parallel.ForEach:{parallelForEachTime.TotalMilliseconds:N2}ms");
			_output.WriteLine($"Parallel.For:    {parallelForTime.TotalMilliseconds:N2}ms");
			_output.WriteLine($"PLINQ:          {plinqTime.TotalMilliseconds:N2}ms");
		}
	}
}
