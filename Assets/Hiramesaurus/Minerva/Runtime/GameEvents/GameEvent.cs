using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hiramesaurus.Minerva.GameEvents
{
    [CreateAssetMenu (menuName = "Minerva/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private enum LogLevel
        {
            None,
            Invocations,
            Listeners,
            All
        }

        internal List<GameEventListener> DynamicListeners;

        [SerializeField] private LogLevel logging;
        [SerializeField] private int expectedCapacity = 3;

        [SerializeField] private bool enableStaticEvent;
        [SerializeField] private UnityEvent staticEvent;

        public int ListenerCount => DynamicListeners.Count;

        private void Awake ()
        {
            DynamicListeners = new List<GameEventListener> (expectedCapacity);
        }

        public void ClearDynamicListeners ()
        {
            DynamicListeners.Clear ();
        }

        public void Raise ()
        {
            for (var i = DynamicListeners.Count - 1; i >= 0; i--)
            {
                DynamicListeners[i].OnEventRaised ();
            }

            if (enableStaticEvent)
            {
                staticEvent.Invoke ();
            }
        }

        /// <summary>
        /// Add Listener and make sure it is note duplicated.
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns>'true' if the listener was added, 'false' otherwise.</returns>
        public bool TryAddListener (GameEventListener listener)
        {
            if (DynamicListeners.Contains (listener))
                return false;

            DynamicListeners.Add (listener);
            return true;
        }

        public void AddListener (GameEventListener listener)
        {
            DynamicListeners.Add (listener);
        }

        /// <summary>
        /// Add Listener and make sure it is note duplicated without returning if it failed of not.
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public void AddUniqueListener (GameEventListener listener)
        {
            if (!DynamicListeners.Contains (listener))
                DynamicListeners.Add (listener);
        }

        public void RemoveListener (GameEventListener listener)
        {
            DynamicListeners.Remove (listener);
        }

        public void RemoveAllListeners ()
        {
            DynamicListeners.Clear ();
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