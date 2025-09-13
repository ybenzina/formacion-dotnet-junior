using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ListUtil
        var nums = ListUtil.Create(new[] { 5, 3, 9, 1 });
        Console.WriteLine("Lista inicial: " + string.Join(", ", nums));
        ListUtil.Add(nums, 4);
        Console.WriteLine("Después Add(4): " + string.Join(", ", nums));
        ListUtil.Sort(nums);
        Console.WriteLine("Después Sort(): " + string.Join(", ", nums));
        var found = ListUtil.Find(nums, x => x > 4);
        Console.WriteLine("Find(x > 4): " + found);
        Console.WriteLine();

        // DictUtil
        var d = new Dictionary<string, int>();
        var added = DictUtil.TryAdd(d, "a", 1);
        Console.WriteLine($"TryAdd('a',1) -> {added}");
        added = DictUtil.TryAdd(d, "a", 2);
        Console.WriteLine($"TryAdd('a',2) (duplicada) -> {added}");
        DictUtil.AddOrUpdate(d, "a", 42);
        Console.WriteLine($"After AddOrUpdate('a',42) -> a = {d["a"]}");

        if (DictUtil.TryGetValue(d, "b", out var vb))
            Console.WriteLine($"TryGetValue('b') -> {vb}");
        else
            Console.WriteLine("TryGetValue('b') -> null");
        Console.WriteLine();

        // Stack/Queue
        var s = StackQueueUtil.CreateStack(new[] { "first", "second" });
        StackQueueUtil.Push(s, "third");
        Console.WriteLine("Stack Pop sequence:");
        while (StackQueueUtil.TryPop(s, out var it)) Console.WriteLine("  " + it);

        var q = StackQueueUtil.CreateQueue<string>();
        StackQueueUtil.Enqueue(q, "one");
        StackQueueUtil.Enqueue(q, "two");
        Console.WriteLine("Queue Dequeue sequence:");
        while (StackQueueUtil.TryDequeue(q, out var iq)) Console.WriteLine("  " + iq);
    }
}
