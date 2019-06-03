using System;
using System.Collections.Generic;


public static class EventSystem
{

    private static Dictionary<Type, List<Action<object>>> listeners = new Dictionary<Type, List<Action<object>>>();


    public static void RegisterListener<T>(Action<object> listener) where T : class
    {
        if (listeners.ContainsKey(typeof(T)) == false)
            listeners.Add(typeof(T), new List<Action<object>>());

        listeners[typeof(T)].Add(listener);
    }

    public static void Send<T>(T events) where T : class
    {
        if (listeners.ContainsKey(typeof(T)) == false)
            return;

        foreach (var action in listeners[typeof(T)])
        {
            action.Invoke(events);
        }
    }

    public static void ClearListener<T>(Action<object> listener) where T : class
    {
        if (listeners.ContainsKey(typeof(T)) == true)
            listeners[typeof(T)].Remove(listener);
    }
}

