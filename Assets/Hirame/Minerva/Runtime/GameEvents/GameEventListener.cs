using UnityEngine;
using UnityEngine.Events;

namespace Hirame.Minerva.GameEvents
{
    public class GameEventListener : ScriptableObject
    {
        public bool EnableInEditMode;      
        public int ParentInstanceId { get; set; }
        
        public GameEvent ListenedEvent;
        public UnityEvent EventHandler;

        public void StartListening ()
        {
            ListenedEvent.AddListener (this);
        }

        public void StopListening ()
        {
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