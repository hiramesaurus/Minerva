using UnityEngine;
using UnityEngine.Events;

namespace Hirame.Minerva.GameEvents
{
    [ExecuteAlways]
    public class GameEventReceiver : MonoBehaviour
    {
        public GameEventListener Listener;
        
        [HideInInspector]
        public GameEvent ListenedEvent;
        [HideInInspector]
        public UnityEvent Event;

        internal void OnEventRaised ()
        {
            Event.Invoke ();
        }
        
        private void OnEnable ()
        {
            Listener.ParentInstanceId = GetInstanceID ();
            Listener.StartListening ();
        }

        private void OnDisable ()
        {
            Listener.StopListening ();
        }

        private void OnDestroy ()
        {
            Listener.Clear ();
        }

        public void ConvertToNewListener ()
        {
            if (Listener == null)
            {
                var listener = ScriptableObject.CreateInstance<GameEventListener> ();
                listener.EventHandler = Event;
                listener.ListenedEvent = ListenedEvent;
                Listener = listener;
                Event = null;
                ListenedEvent = null;
            }
        }
    }
}