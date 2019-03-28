using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

namespace Hiramesaurus.Minerva.GameEvents
{
    [CreateAssetMenu (menuName = "Minerva/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [Flags]
        public enum LogFlags
        {
            Invocations = 1,
            Listeners = 2,
            Caller = 4
        }

        public List<EventListener> DynamicListeners;

        public LogFlags Logging;
        
        [SerializeField] private int defaultCapacity = 3;
        
        [SerializeField] private bool enableStaticEvent;
        [SerializeField] private UnityEvent staticEvent;

        public int ListenerCount => DynamicListeners.Count;

        private void Awake ()
        {
            DynamicListeners = new List<EventListener> (defaultCapacity);
        }

        public void Raise ()
        {
            Log ($"Event Raised -> <color=green>{name}</color>", LogFlags.Invocations);

            if (enableStaticEvent)
            {
                staticEvent.Invoke ();
            }

            for (var i = DynamicListeners.Count - 1; i >= 0; i--)
            {
                DynamicListeners[i].OnEventRaised ();
            }
        }

        public void AddListener (EventListener listener)
        {
            Log ($"Added Listener: {listener.Owner.name}", LogFlags.Listeners);
            DynamicListeners.Add (listener);
        }

        public void RemoveListener (EventListener listener)
        {
            Log ($"Removed Listener: {listener.Owner.name}", LogFlags.Listeners);
            DynamicListeners.Remove (listener);
        }
        
        public void ClearDynamicListeners ()
        {
            Log ("Removed ALL listeners.", LogFlags.Listeners);
            DynamicListeners.Clear ();
        }

        [Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
        private void Log (string message, LogFlags flag)
        {
            if ((Logging & flag) != flag) 
                return;
            
            if ((Logging & LogFlags.Caller) == LogFlags.Caller)
            {
                var frame = new StackTrace (true).GetFrame (2);
                var method = frame.GetMethod ();
                var callerClass = method.DeclaringType;
                var callerMethod = method.Name;
                
                Debug.Log ($"[Minerva]: {message}\nCaller: {callerClass}.{callerMethod}");
            }
            else
            {
                Debug.Log ($"[Minerva]: {message}");
            }
        }

    }

    public abstract class GameEvent<T> : GameEvent
        where T : unmanaged
    {
        public T EventData;
    }

    public abstract class GameEvent<T1, T2> : GameEvent
        where T1 : unmanaged, IEquatable<T1>
        where T2 : GlobalValue<T1>
    {
        public bool LinkGlobal;
        public T2 EventData;

        public T1 GetEventRuntimeValue => EventData.RuntimeValue;
        public T1 GetEventInitialValue => EventData.InitialValue;
    }
}