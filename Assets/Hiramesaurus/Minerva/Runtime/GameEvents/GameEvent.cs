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

        public void Raise (
            [CallerFilePath] string callerFilePath = "",
            [CallerMemberName] string callerMemberName = "")
        {
            Log ($"Event Raised -> <color=green>{name}</color>", LogFlags.Invocations, 
                $"Caller: {callerFilePath}.{callerMemberName}.", LogFlags.Caller);

            if (enableStaticEvent)
            {
                staticEvent.Invoke ();
            }

            for (var i = DynamicListeners.Count - 1; i >= 0; i--)
            {
                DynamicListeners[i].OnEventRaised ();
            }
        }

        /// <summary>
        /// Add Listener and make sure it is note duplicated.
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>'true' if the listener was added, 'false' otherwise.</returns>
        public bool TryAddListener (EventListener listener, [CallerMemberName] string callerMemberName = "")
        {
            if (DynamicListeners.Contains (listener))
                return false;

            AddListener (listener, callerMemberName);
            return true;
        }

        public void AddListener (EventListener listener, [CallerMemberName] string callerMemberName = "")
        {
            Log ($"Added Listener: {listener}", LogFlags.Listeners, 
                $"Caller: {callerMemberName}.", LogFlags.Caller);
            DynamicListeners.Add (listener);
        }

        public void RemoveListener (EventListener listener, [CallerMemberName] string callerMemberName = "")
        {
            Log ($"Removed Listener: {listener}", LogFlags.Listeners, 
                $"Caller: {callerMemberName}.", LogFlags.Caller);
            DynamicListeners.Remove (listener);
        }
        
        public void ClearDynamicListeners ([CallerMemberName] string callerMemberName = "")
        {
            Log ("Removed ALL listeners.", LogFlags.Listeners, 
                $"Caller: {callerMemberName}.", LogFlags.Caller);
            DynamicListeners.Clear ();
        }

        [Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
        private void Log (string message, LogFlags flag)
        {
            if ((Logging & flag) == flag)
                Debug.Log ($"[Minerva]: {message}");
        }

        [Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
        private void Log (string message, LogFlags flag, string info, LogFlags infoFlag)
        {
            if ((Logging & infoFlag) == infoFlag)
            {
                Log ($"{message}.\n{info}\n", flag);
                return;
            }
            Log (message, flag);
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