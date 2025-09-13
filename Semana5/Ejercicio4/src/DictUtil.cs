using System;
using System.Collections.Generic;

public static class DictUtil
{
    // Intenta añadir, devuelve true si añadio, false si ya existia
    public static bool TryAdd<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue value)
        where TKey : notnull
    {
        if (dict.ContainsKey(key)) return false;
        dict.Add(key, value);
        return true;
    }

    // Añade o actualiza
    public static void AddOrUpdate<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue value)
        where TKey : notnull
    {
        dict[key] = value;
    }

    // Intenta obtener valor
    public static bool TryGetValue<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, out TValue? value)
        where TKey : notnull
    {
        return dict.TryGetValue(key, out value);
    }
}
