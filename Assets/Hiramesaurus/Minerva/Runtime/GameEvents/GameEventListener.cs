using UnityEngine;
using UnityEngine.Events;

namespace Hiramesaurus.Minerva.GameEvents
{
    [System.Serializable]
    public class GameEventListener
    {
        public bool EnableInEditMode;
        
        public GameEvent ListenedEvent;
        public UnityEvent EventHandler;

        public void StartListening ()
        {
            if (ListenedEvent != null)
                ListenedEvent.AddListener (this);
        }

        public void StopListening ()
        {
            if (ListenedEvent != null)
                ListenedEvent.RemoveListener (this);
        }
        
        public void OnEventRaised ()
        {
            EventHandler.Invoke ();
        }

        public void Clear ()
        {
            ListenedEvent.RemoveListener (this);
            EventHandler.RemoveAllListeners ();
        }
    }

}