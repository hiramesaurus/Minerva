using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private List<GameEventListener> dynamicListeners = new List<GameEventListener> ();

        [SerializeField] private bool enableStaticEvent;
        [SerializeField] private UnityEvent staticEvent;

        [System.Obsolete ("Use 'Raise' instead.")]
        public void RaiseEvent ()
        {
            Raise ();
        }

        public void Raise ()
        {
            for (var i = dynamicListeners.Count - 1; i >= 0; i--)
            {
                dynamicListeners[i].OnEventRaised ();
            }

            if (enableStaticEvent)
            {
                staticEvent.Invoke ();
            }
        }
        
        /// <summary>
        /// Add Listener and make sure it is note duplicated.
        /// </summary>
        /// <param name="listener"></param>
        /// <returns>'true' if the listener was added, 'false' otherwise.</returns>
        public bool TryAddListener (GameEventListener listener)
        {
            if (dynamicListeners.Contains (listener))
                return false;

            dynamicListeners.Add (listener);
            return true;
        }

        public void AddListener (GameEventListener listener)
        {
            dynamicListeners.Add (listener);
        }

        /// <summary>
        /// Add Listener and make sure it is note duplicated without returning if it failed of not.
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public void AddUniqueListener (GameEventListener listener)
        {
            if (!dynamicListeners.Contains (listener))
                dynamicListeners.Add (listener);
        }

        public void RemoveListener (GameEventListener listener)
        {
            dynamicListeners.Remove (listener);
        }

        public void RemoveAllListeners ()
        {
            dynamicListeners.Clear ();
        }
    }

    public abstract class GameEvent<T> : GameEvent
        where T : unmanaged
    {
        public T EventData;
    }

    public abstract class GameEvent<T1, T2> : GameEvent
        where T1 : unmanaged
        where T2 : GlobalValue<T1>
    {
        public bool LinkedGlobalData;
        public T2 EventData;

        public T1 GetEventRuntime => EventData.Runtime;
        public T1 GetEventInitial => EventData.Initial;
    }
}