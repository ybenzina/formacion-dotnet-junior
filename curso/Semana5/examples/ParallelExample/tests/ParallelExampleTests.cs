using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class ParallelExampleTests
{
    [Fact]
    public void ParallelAndSequentialProduceSameResult()
    {
        var n = 500;
        var items = Enumerable.Range(0,n).ToArray();

        var s = ParallelExample.ProcessSequential(items);
        var p = ParallelExample.ProcessParallelForEach(items);

        Assert.Equal(s, p);
    }
}
