using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public static class EventManager
    {
        private static Dictionary<System.Type, List<GameEventListenerBase>> listeners;

        static EventManager()
        {
            listeners = new Dictionary<System.Type, List<FunRace.GameEventListenerBase>>();
        }

        public static void AddListener<GameEvent>(GameEventListener<GameEvent> listener) where GameEvent : struct
        {
            System.Type eventType = typeof(GameEvent);

            if (!listeners.ContainsKey(eventType))
            {
                listeners[eventType] = new List<GameEventListenerBase>();
            }

            if (!listeners[eventType].Contains(listener))
            {
                listeners[eventType].Add(listener);
            }
        }

        public static void RemoveListener<GameEvent>(GameEventListener<GameEvent> listener) where GameEvent : struct
        {
            System.Type eventType = typeof(GameEvent);

            if (!listeners[eventType].Contains(listener))
            {
                listeners[eventType].Remove(listener);
            }

            if (listeners[eventType].Count == 0)
            {
                listeners.Remove(eventType);
            }
        }

        public static void TriggerEvent<GameEvent>(GameEvent newEvent) where GameEvent : struct
        {
            foreach (GameEventListenerBase listener in listeners[typeof(GameEvent)])
            {
                (listener as GameEventListener<GameEvent>).OnGameEvent(newEvent);
            }
        }
    }

    public interface GameEventListenerBase { };

    public interface GameEventListener<T> : GameEventListenerBase
    {
        void OnGameEvent(T gameEvent);
    }
}
