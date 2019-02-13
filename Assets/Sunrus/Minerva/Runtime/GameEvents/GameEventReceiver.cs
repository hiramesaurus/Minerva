using UnityEngine;
using UnityEngine.Events;

namespace Sunrus.Minerva.GameEvents
{
    [ExecuteAlways]
    public class GameEventReceiver : MonoBehaviour
    {
        public GameEventListener Listener;

        [HideInInspector] public GameEvent ListenedEvent;
        [HideInInspector] public UnityEvent Event;

        private void OnEnable ()
        {
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
                var listener = new GameEventListener
                {
                    EventHandler = Event,
                    ListenedEvent = ListenedEvent
                };
                Listener = listener;
                Event = null;
                ListenedEvent = null;
            }
        }
    }
}