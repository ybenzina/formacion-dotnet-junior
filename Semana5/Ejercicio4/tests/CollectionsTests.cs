using System;
using System.Collections.Generic;
using Xunit;

public class CollectionsTests
{
    // ListUtil
    [Fact]
    public void List_Add_Remove_Sort_Find_Works()
    {
        var list = ListUtil.Create(new[] { 3, 1, 2 });
        Assert.Equal(3, list.Count);

        ListUtil.Add(list, 4);
        Assert.Contains(4, list);

        var removed = ListUtil.Remove(list, 1);
        Assert.True(removed);
        Assert.DoesNotContain(1, list);

        ListUtil.Sort(list);
        Assert.Equal(new List<int> { 2, 3, 4 }, list);

        var found = ListUtil.Find(list, x => x > 2);
        Assert.Equal(3, found);
    }

    [Fact]
    public void List_Remove_ReturnsFalse_WhenNotPresent()
    {
        var list = ListUtil.Create<int>();
        var removed = ListUtil.Remove(list, 10);
        Assert.False(removed);
    }

    // DictUtil
    [Fact]
    public void Dict_TryAdd_And_AddOrUpdate_Work()
    {
        var d = new Dictionary<string, int>();
        var added = DictUtil.TryAdd(d, "k", 1);
        Assert.True(added);
        Assert.Equal(1, d["k"]);

        // duplicate add, should fail
        added = DictUtil.TryAdd(d, "k", 2);
        Assert.False(added);
        Assert.Equal(1, d["k"]);

        // update
        DictUtil.AddOrUpdate(d, "k", 99);
        Assert.Equal(99, d["k"]);
    }

    [Fact]
    public void Dict_TryGetValue_ReturnsFalse_WhenMissing()
    {
        var d = new Dictionary<int, string>();
        var ok = DictUtil.TryGetValue(d, 5, out var value);
        Assert.False(ok);
        Assert.Null(value);
    }

    // Stack/Queue
    [Fact]
    public void Stack_Pop_Throws_OnEmpty_But_TryPop_ReturnsFalse()
    {
        var s = StackQueueUtil.CreateStack<int>();
        Assert.False(StackQueueUtil.TryPop(s, out var v));
        Assert.Equal(default(int), v);

        Assert.Throws<InvalidOperationException>(() => StackQueueUtil.Pop(s));
    }

    [Fact]
    public void Queue_Dequeue_Throws_OnEmpty_But_TryDequeue_ReturnsFalse()
    {
        var q = StackQueueUtil.CreateQueue<int>();
        Assert.False(StackQueueUtil.TryDequeue(q, out var v));
        Assert.Equal(default(int), v);

        Assert.Throws<InvalidOperationException>(() => StackQueueUtil.Dequeue(q));
    }

    [Fact]
    public void Stack_Queue_BasicFlow_Works()
    {
        var s = StackQueueUtil.CreateStack(new[] { 1, 2 });
        StackQueueUtil.Push(s, 3);
        Assert.True(StackQueueUtil.TryPop(s, out var sp) && sp == 3);

        var q = StackQueueUtil.CreateQueue<int>();
        StackQueueUtil.Enqueue(q, 10);
        StackQueueUtil.Enqueue(q, 20);
        Assert.True(StackQueueUtil.TryDequeue(q, out var dq) && dq == 10);
        Assert.True(StackQueueUtil.TryDequeue(q, out var dq2) && dq2 == 20);
    }
}
