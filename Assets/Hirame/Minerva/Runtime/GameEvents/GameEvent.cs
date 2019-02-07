using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Hirame.Minerva.GameEvents
{
    [CreateAssetMenu (menuName = "Minerva/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [FormerlySerializedAs ("dynamicListeners")] public List<GameEventListener> DynamicListeners = new List<GameEventListener> ();

        [SerializeField] private bool enableStaticEvent;
        [SerializeField] private UnityEvent staticEvent;

        [System.Obsolete ("Use 'Raise' instead.")]
        public void RaiseEvent ()
        {
            Raise ();
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
        where T1 : unmanaged
        where T2 : GlobalValue<T1>
    {
        public bool LinkGlobal;
        public T2 EventData;

        public T1 GetEventRuntime => EventData.Runtime;
        public T1 GetEventInitial => EventData.Initial;
    }
}