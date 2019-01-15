using UnityEngine;
using UnityEngine.Events;

namespace Hirame.Minerva
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent ListenedEvent;
        public UnityEvent Event;
        
        internal void OnEventRaised ()
        {
            Event.Invoke ();
        }
    }
}
