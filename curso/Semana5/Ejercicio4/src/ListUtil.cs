using System;
using System.Collections.Generic;

public static class ListUtil
{
    // Crea una lista opcionalmente con elementos iniciales
    public static List<T> Create<T>(IEnumerable<T>? items = null) =>
        items is null ? new List<T>() : new List<T>(items);

    // Añadir elemento
    public static void Add<T>(List<T> list, T item) => list.Add(item);

    // Eliminar
    public static bool Remove<T>(List<T> list, T item) => list.Remove(item);

    // Si se pasa comparacion la usa, si no usa Sort()
    public static void Sort<T>(List<T> list, Comparison<T>? comparison = null)
    {
        if (comparison is null)
            list.Sort();
        else
            list.Sort(comparison);
    }

    // Devuelve default(T) si no encuentra
    public static T? Find<T>(List<T> list, Predicate<T> predicate) => list.Find(predicate);
}
