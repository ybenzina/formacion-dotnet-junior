using System;
using System.Collections.Generic;

public static class StackQueueUtil
{
    // Stack helpers
    public static Stack<T> CreateStack<T>(IEnumerable<T>? items = null) =>
        items is null ? new Stack<T>() : new Stack<T>(items);

    public static void Push<T>(Stack<T> stack, T item) => stack.Push(item);

    public static T Pop<T>(Stack<T> stack) => stack.Pop(); // InvalidOperationException si esta vacio

    public static bool TryPop<T>(Stack<T> stack, out T? item)
    {
        if (stack.Count == 0) { item = default; return false; }
        item = stack.Pop();
        return true;
    }

    // Queue helpers
    public static Queue<T> CreateQueue<T>(IEnumerable<T>? items = null) =>
        items is null ? new Queue<T>() : new Queue<T>(items);

    public static void Enqueue<T>(Queue<T> queue, T item) => queue.Enqueue(item);

    public static T Dequeue<T>(Queue<T> queue) => queue.Dequeue(); // lanza InvalidOperationException si vacío

    public static bool TryDequeue<T>(Queue<T> queue, out T? item)
    {
        if (queue.Count == 0) { item = default; return false; }
        item = queue.Dequeue();
        return true;
    }
}
